using CodeGenerator.WPF.LIB.ViewModels;

namespace CodeGenerator.WPF.LIB.Models;

public class Breadcrumb
{
    public ViewModel? ViewModel { get; set; }

    public string? Title { get; set; }

    public int Position { get; set; }
}
