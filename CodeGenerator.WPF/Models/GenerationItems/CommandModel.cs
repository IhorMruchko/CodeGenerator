using System.Runtime.Serialization;
using System.Collections.Generic;

namespace CodeGenerator.WPF.Models.GenerationItems;

public class CommandModel: RequestGenerationItem
{
    public string Class { get; set; } = "Class1";

    public string Command { get; set; } = "cmd";

    public List<RequestGenerationItem> Items { get; set; } = new();
}
