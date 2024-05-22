using CodeGenerator.WPF.LIB.Base;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectGridViewModel : ProjectsViewModelBase
{
    public ProjectGridViewModel(ItemsObservableCollection<ProjectViewModel> projects) : base(projects)
    {}

    protected override void ConvertObjects()
    {
        
    }
}
