using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class PreviewGenerationDialogViewModel: DialogViewModel
{
    public string? AttributesGeneration { get; set; }
    
    public string? FluentApiGeneration { get; set; }
}
