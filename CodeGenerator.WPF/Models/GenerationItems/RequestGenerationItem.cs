using CodeGenerator.LIB.Generation;

namespace CodeGenerator.WPF.Models.GenerationItems;

public abstract class RequestGenerationItem: GenerationItem
{
    public string Help { get; set; } = "Help";

    public abstract string GenerateFluent();

    public abstract string GenerateAttributes();
}
