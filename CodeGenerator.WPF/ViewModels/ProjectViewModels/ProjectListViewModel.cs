using CodeGenerator.WPF.Models;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectListViewModel : ProjectViewModel
{
    public ProjectListViewModel(Project? source = null) : base(source) { }
}
