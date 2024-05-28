using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;

namespace CodeGenerator.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public SliderViewModel Slider { get; set; } = new SliderViewModel().AddNext(new ProjectsViewModel()).AddNext(new SettingsViewModel());
    
    public MainWindowViewModel()
    {
    }
}
