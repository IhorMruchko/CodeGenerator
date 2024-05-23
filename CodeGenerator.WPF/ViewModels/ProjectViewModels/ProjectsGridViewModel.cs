using CodeGenerator.WPF.LIB.Base;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectsGridViewModel : ProjectsViewModelBase
{
    public ProjectsGridViewModel(ItemsObservableCollection<ProjectViewModel> projects) : base(projects)
    {
    }

    protected override void ConvertObjects()
    {
        throw new System.NotImplementedException();
    }
}
