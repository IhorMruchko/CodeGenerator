using CodeGenerator.WPF.LIB.ViewModels;
using CodeGenerator.WPF.ViewModels.ProjectViewModels;

namespace CodeGenerator.WPF.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public SliderVM Slider { get; set; } = new SliderVM().AddNext(new ProjectsViewModel());
    
    public MainWindowViewModel()
    {
    }
}
