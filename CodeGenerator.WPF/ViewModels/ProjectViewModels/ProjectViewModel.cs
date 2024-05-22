using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
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
        var editDialog = new ProjectDialogViewModel(copy);
        editDialog.PropertyChanged += EditDialog_PropertyChanged;
        mv.OpenDialogWindow(editDialog);

    }

    private void EditDialog_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (sender is not ProjectDialogViewModel pdvm || e.PropertyName != nameof(ProjectDialogViewModel.HasValue) || !pdvm.HasValue) return;
        this.CopyFrom(pdvm.Project);
    }
}
