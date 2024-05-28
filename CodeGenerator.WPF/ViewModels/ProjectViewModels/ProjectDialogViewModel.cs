using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectDialogViewModel : DialogViewModel, IDirectoryProvider
{
    private string? _dialogTitle;

    private string? _directory;

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
}
