using CodeGenerator.WPF.LIB.Base;
using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.Resources.Constants;
using CodeGenerator.WPF.Resources.Enums;

namespace CodeGenerator.WPF.ViewModels.ProjectViewModels;

public class ProjectLayoutViewModel : ViewModel
{
    public ProjectViewLayout Layout { get; set; } = Constants.DEFAULT_PROJECT_LAYOUT;
}
