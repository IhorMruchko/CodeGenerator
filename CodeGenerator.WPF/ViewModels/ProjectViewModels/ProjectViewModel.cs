using CodeGenerator.LIB.Extensions;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Models;
using CodeGenerator.WPF.Resources;
using CodeGenerator.WPF.Resources.Constants;
using CodeGenerator.WPF.Resources.Enums;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectViewModel : ViewModel
{
    private ProjectViewLayout _layout = Constants.DEFAULT_PROJECT_LAYOUT;
    
    public ProjectViewLayout Layout 
    {
        get => _layout;
        set
        {
            _layout = value;
            OnPropertyChanged();
        }
    }
    
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

    public ProjectViewModel(Project? source = null)
    {
        Project = source ?? new Project();
    }

    public RelayedCommand OpenEditDialogCommand => new(OpenEditDialog);

    public RelayedCommand OpenProjectCommand => new(OpenProject);

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
            this.CopyFrom(copy);
        };
        
        Commands.OpenDialogCommand.Execute(new object[] { mv, editDialog });

    }

    private void OpenProject(object? parameter = null)
    {
        if (parameter
            .ToParser()
            .Parse(out MainWindow mv)
            .Failed) return;

        mv.ChangeContent(new ProjectElementsViewModel());
    }
}
