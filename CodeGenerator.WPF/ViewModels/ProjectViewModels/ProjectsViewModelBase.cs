using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.ViewModels;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public abstract class ProjectsViewModelBase : ViewModel
{
    public ItemsObservableCollection<ProjectViewModel> Projects { get; set; }
    
    public ProjectsViewModelBase(ItemsObservableCollection<ProjectViewModel> projects)
    {
        Projects = projects;
        ConvertObjects();
    }

    protected abstract void ConvertObjects();
}
