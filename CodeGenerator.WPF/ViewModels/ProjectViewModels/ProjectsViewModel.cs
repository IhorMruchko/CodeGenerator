using CodeGenerator.LIB.Utils;
using CodeGenerator.LIB.Utils.Connections;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.Resources.Constants;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.Views;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectsViewModel : ViewModel
{
    public SliderVM ProjectDisplayLayout { get; set; }

    private readonly BackgroundWorker _worker;

    private readonly JsonIOService<Project[]> _connection = new(Constants.APPLICATION_PATH, Constants.PROJECTS_FILENAME);

    protected ItemsObservableCollection<ProjectViewModel> Projects = new() { 
    };

    protected ObservableCollection<Project> ProjectData = new();

    public ProjectsViewModel()
    {
        _worker = BackgroundWorker.Worker;
        Projects = new ItemsObservableCollection<ProjectViewModel>(_connection.TryRead(out var projects) ? projects?.Select(project => new ProjectViewModel(project)) ?? Array.Empty<ProjectViewModel>() : Array.Empty<ProjectViewModel>());
        Projects.CollectionChanged += (_, _) => Save();
        Projects.ItemPropertyChanged += (_, _) => Save();
        ProjectDisplayLayout = new SliderVM().AddNext(new ProjectsListViewModel(Projects))
                                             .AddNext(new ProjectsGridViewModel(Projects));
    }

    private void Save()
    {
        _worker.AddTask(new Task(() => _connection.Write(Projects.Select(model => model.Project).ToArray())));
    }

    public RelayedCommand AddProject => new(CreateProject);

    public RelayedCommand RemoveProjectCommand => new(RemoveProject);

    public RelayedCommand OpenProjectCommand => new(OpenProject, CanOpenProject);

    private void OpenProject(object? parameter = null)
    {
        if (parameter is not object[] parameters
            || parameters.Length != 2
            || parameters[0] is not ProjectViewModel pvm
            || parameters[1] is not MainWindow mv) return;

        mv.ChangeContent(new ProjectFilesViewModel()
        {
            Source = pvm.Project
        });
    }

    private bool CanOpenProject(object? parameter = null)
    {
        return parameter is object[] parameters
            && parameters.Length == 2
            && parameters[0] is ProjectViewModel pvm
            && Directory.Exists(pvm.Directory)
            && parameters[1] is MainWindow;
    }

    private void CreateProject(object? parameter = null)
    {
        if (parameter is not MainWindow mainWindow) return;

        var dialog = new ProjectDialogViewModel() 
        { 
            DialogTitle = "Create Project"
        };

        Commands.OpenDialogCommand.Execute(new object[] { mainWindow, dialog });

        dialog.DialogSuccess += () =>
        {
            Projects.Add(new ProjectViewModel(dialog.Project));

            var directoryInfo = Directory.CreateDirectory(Path.Combine(
                dialog.Project.Directory,
                dialog.Project.Title
            ));
            directoryInfo.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        };
    }

    private void RemoveProject(object? parameter=null)
    {
        if (parameter is not object[] source || source.Length != 2 || source[0] is not ProjectViewModel pvm || source[1] is not MainWindow mv) return;

        var confrimDialog = new ConfirmDialogViewModel()
        {
            Target = pvm,
            ConfirmationText = $"Are you sure you want to delete this ({pvm.Title}) project?"
        };
        confrimDialog.DialogSuccess += () =>
        {
            Projects.Remove(pvm);
            if (Directory.Exists(Path.Combine(pvm.Project.Directory, pvm.Project.Title)))
            {
                Directory.Delete(Path.Combine(pvm.Project.Directory, pvm.Project.Title));
            }
        };
        
        Commands.OpenDialogCommand.Execute(new object[] { mv, confrimDialog });
    }
}
