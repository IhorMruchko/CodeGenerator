using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.Views;
using System.Diagnostics;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectViewModel : ViewModel
{
    public Project Project { get; set; } = new Project();

    public string Title
    {
        get => Project.Title;
        set
        {
            Project.Title = value;
            OnPropertyChanged();
        }
    }

    public string Directory
    {
        get => Project.Directory;
        set
        {
            Project.Directory = value;
            OnPropertyChanged();
        }
    }


    public ProjectViewModel(Project? source = null)
    {
        Project = source ?? new Project();
    }

    public RelayedCommand OpenInFileExplorerCommand => new(OpenInFileExplorer, HasDirectory);

    public RelayedCommand OpenEditDialogCommand => new(OpenEditDialog);

    private void OpenInFileExplorer(object? parameter = null)
    {
        if (System.IO.Directory.Exists(Directory))
        {
            Process.Start("explorer.exe", Directory);
        }
    }

    private bool HasDirectory(object? parameter = null) => System.IO.Directory.Exists(Directory);

    private void OpenEditDialog(object? parameter = null) 
    {
        if (parameter is not MainWindow mv) return;


        var copy = Project.Copy();
        var editDialog = new ProjectDialogViewModel(copy)
        {
            DialogTitle = "Edit project"
        };
        editDialog.DialogSuccess += () =>
        {
            this.CopyFrom(editDialog.Project);
        };
        Commands.OpenDialogCommand.Execute(new object[] { mv, editDialog });

    }
}
