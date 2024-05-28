namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public abstract class CommandInnerItemViewModel : GenerationElementViewModel
{
    public abstract string GenerateAttributes(int tabIndex);

    public abstract string GenerateFluentApi();
}
