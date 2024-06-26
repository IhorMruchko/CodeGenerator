﻿using CodeGenerator.WPF.Models.GenerationItems;
using System.Collections.Generic;

namespace CodeGenerator.WPF.Models;

public class Project
{
    public string Title { get; set; } = string.Empty;

    public string Directory { get; set; } = string.Empty;

    public List<CommandModel> Items { get; set; } = new();
}
