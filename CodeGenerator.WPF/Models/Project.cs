using CodeGenerator.LIB.Generation;
using System.Collections.Generic;

namespace CodeGenerator.WPF.Models;

public class Project
{
    public string Title { get; set; } = string.Empty;

    public List<GenerationItem> Files { get; set; } = new();
}
