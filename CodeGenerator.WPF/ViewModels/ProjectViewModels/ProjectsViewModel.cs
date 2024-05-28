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
using PropertyChangedEventArgs = System.ComponentModel.PropertyChangedEventArgs;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CodeGenerator.WPF.Resources.Enums;
using CodeGenerator.LIB.Extensions;
using CodeGenerator.LIB.Generation;
using System.Diagnostics;
using System.Threading;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectsViewModel : ViewModel
{
    private readonly BackgroundWorker _worker;

    private readonly JsonIOService<Project[]> _connection = new(Constants.APPLICATION_PATH, Constants.PROJECTS_FILENAME);

    private ProjectLayoutViewModel _selectedViewModel = new();

    public ItemsObservableCollection<ProjectViewModel> Projects { get; set; } = new();


    public ProjectLayoutViewModel SelectedViewModel
    {
        get => _selectedViewModel;
        set
        {
            _selectedViewModel = value;
            OnPropertyChanged();
        }
    }

    public ProjectsViewModel()
    {
        _worker = BackgroundWorker.Worker;
        Projects = new ItemsObservableCollection<ProjectViewModel>(_connection.TryRead(out var projects) ? projects?.Select(project => new ProjectViewModel(project)) ?? Array.Empty<ProjectViewModel>() : Array.Empty<ProjectViewModel>());
        Projects.CollectionChanged += (_, _) => Save();
        Projects.ItemPropertyChanged += (_, e) => Save();
    }

    private void Save(PropertyChangedEventArgs? args = null)
    {
        if (args is not null && args.PropertyName == nameof(ProjectViewModel.Layout)) return;

        _worker.AddTask(() => _connection.Write(Projects.Select(model => model.Project).ToArray()));
    }

    public RelayedCommand AddProject => new(CreateProject);

    public RelayedCommand ChangeLayoutCommand => new(ChangeLayout);

    public RelayedCommand RemoveProjectCommand => new(RemoveProject);

    private void CreateProject(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        var dialog = new ProjectDialogViewModel()
        {
            DialogTitle = "Create Project"
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, dialog });

        dialog.DialogSuccess += () =>
        {
            var path = Path.Combine(dialog.Directory, dialog.Title);
            dialog.Project.Directory = path;
            BackgroundWorker.Worker.AddTask(() =>
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var filePath = Path.Combine(path, dialog.Title + ".csproj");
                Process.Start(new ProcessStartInfo("dotnet", $"new sln --output {path}")
                {
                    CreateNoWindow = true
                });

                File.WriteAllText(filePath, Constants.PROJ_FILE_CONTENT);
            });

            BackgroundWorker.Worker.AddTask(() =>
            {
                Thread.Sleep(1000);
                Process.Start(new ProcessStartInfo("dotnet", $"sln add {dialog.Title}.csproj")
                {
                    WorkingDirectory = path,
                    CreateNoWindow = true,
                });
            });

            BackgroundWorker.Worker.AddTask(() =>
            {
                var filePath = Path.Combine(path, "Program.cs");
                File.WriteAllText(filePath, Constants.ENTRY_POINT);
            });

            Projects.Add(new ProjectViewModel(dialog.Project));
        };
    }

    private void RemoveProject(object? parameter = null)
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
            if (Directory.Exists(pvm.Project.Directory))
                Directory.Delete(pvm.Project.Directory, true);
        };

        Commands.OpenDialogCommand.Execute(new object[] { mv, confrimDialog });
    }

    private void ChangeLayout(object? parameter = null)
    {
        if (parameter is not ProjectViewLayout layout || layout == SelectedViewModel.Layout) return;


        SelectedViewModel.Layout = layout;
        
        var copy = SelectedViewModel;
        SelectedViewModel = null;
        SelectedViewModel = copy;
        
        foreach (var project in Projects)
        {
            project.Layout = layout;
        }

    }
}
