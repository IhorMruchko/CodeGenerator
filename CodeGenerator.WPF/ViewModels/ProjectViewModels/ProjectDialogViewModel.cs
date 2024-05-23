using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.ViewModels.BaseModels;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectDialogViewModel : DialogViewModel
{
    private string? _dialogTitle;

    public ProjectDialogViewModel()
    {

    }

    public ProjectDialogViewModel(Project source)
    {
        Project = source;
    }

    public Project Project { get; set; } = new Project();

    public string? DialogTitle
    {
        get => _dialogTitle;
        set
        {
            _dialogTitle = value;
            OnPropertyChanged();
        }
    }

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

    public RelayedCommand OpenFileDialogCommand => new(OpenFileDialog);

    private void OpenFileDialog(object? parameter = null)
    {
        var directoryDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            InitialDirectory = parameter as string
        };

        if (directoryDialog.ShowDialog() != CommonFileDialogResult.Ok) return;
        Directory = directoryDialog.FileName!;
    }
}
