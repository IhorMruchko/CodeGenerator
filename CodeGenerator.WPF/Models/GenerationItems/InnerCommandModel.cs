using System.Collections.Generic;

namespace CodeGenerator.WPF.Models.GenerationItems;

public class InnerCommandModel: CommandInnerItemModel
{
    public string Class { get; set; } = "Class1";

    public string Command { get; set; } = "cmd";

    public string Help { get; set; } = "Help";

    public List<CommandInnerItemModel> Items { get; set; } = new();
}
