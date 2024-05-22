using CodeGenerator.LIB.ProgramingLanguages.PythonProgramingLanguage;
using CodeGenerator.LIB.Utils.Connections;
using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources.Constants;
using CodeGenerator.WPF.ViewModels.BaseModels;
using CodeGenerator.WPF.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectsViewModel : ViewModel
{
    public SliderVM ProjectDisplayLayout { get; set; }

    private JsonIOService<Project[]> _connection = new(Constants.APPLICATION_PATH, Constants.PROJECTS_FILENAME);

    // TODO: Add custom inner collection observable
    protected ItemsObservableCollection<ProjectViewModel> Projects = new() { 
        // TODO: Add reading from file
    };

    protected ObservableCollection<Project> ProjectData = new();

    public ProjectsViewModel()
    {
        Projects = new ItemsObservableCollection<ProjectViewModel>(_connection.TryRead(out var projects) ? projects?.Select(project => new ProjectViewModel(project)) ?? Array.Empty<ProjectViewModel>() : Array.Empty<ProjectViewModel>());
        Projects.CollectionChanged += Projects_CollectionChanged;
        Projects.ItemPropertyChanged += Projects_ItemPropertyChanged;
        ProjectDisplayLayout = new SliderVM().AddNext(new ProjectsListViewModel(Projects))
                                             .AddNext(new ProjectGridViewModel(Projects));
    }

    private void Projects_ItemPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        _connection.Write(Projects.Select(model => model.Project).ToArray());
    }

    private void Projects_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        _connection.Write(Projects.Select(model => model.Project).ToArray());
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

        var dialog = new ProjectDialogViewModel();

        mainWindow.OpenDialogWindow(dialog);

        dialog.PropertyChanged += Dialog_PropertyChanged;
    }

    private void RemoveProject(object? parameter=null)
    {
        if (parameter is not object[] source || source.Length != 2 || source[0] is not ProjectViewModel pvm || source[1] is not MainWindow mv) return;

        var confrimDialog = new ConfirmDialogViewModel()
        {
            Target = pvm,
            ConfirmationText = $"Are you sure you want to delete this ({pvm.Title}) project?"
        };
        confrimDialog.PropertyChanged += ConfrimDialog_PropertyChanged;
        mv.OpenDialogWindow(confrimDialog);
    }

    private void ConfrimDialog_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (sender is not ConfirmDialogViewModel cdvm || e.PropertyName != nameof(DialogViewModel.HasValue) || !cdvm.HasValue || cdvm.Target is not ProjectViewModel pvm) return;
        Projects.Remove(pvm);
    }

    private void Dialog_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(ProjectDialogViewModel.HasValue)) return;
        if (sender is not ProjectDialogViewModel pdvm) return;
        if (!pdvm.HasValue) return;
        Projects.Add(new ProjectViewModel(pdvm.Project));
    }
}
