using CodeGenerator.WPF.LIB.Base;
using System.Linq;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectsListViewModel : ProjectsViewModelBase
{
    public ItemsObservableCollection<ProjectListViewModel> ListProjects { get; set; } = new ItemsObservableCollection<ProjectListViewModel>();

    public ProjectsListViewModel(ItemsObservableCollection<ProjectViewModel> projects) : base(projects)
    {
    }

    protected override void ConvertObjects()
    {
        ListProjects = new(Projects.Select(project => new ProjectListViewModel(project.Project)));
        Projects.CollectionChanged += Projects_CollectionChanged;
    }

    private void Projects_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ListProjects.Add(new ProjectListViewModel(new Models.Project() { Title = "Test" }));
    }
}
