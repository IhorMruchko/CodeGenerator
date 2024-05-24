﻿using CodeGenerator.LIB.Generation;
using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public abstract class GenerationElementViewModel: ViewModel
{
    public RelayedCommand GenerateCommand => new(Generate);

    public RelayedCommand PreviewCommand => new(Preview);

    public RelayedCommand EditCommand => new(Edit);

    public RelayedCommand DeleteCommand => new(Delete);

    protected abstract void Preview(object? parameter = null);
    
    protected abstract void Generate(object? parameter = null);

    protected abstract void Edit(object? parameter = null);

    protected abstract void Delete(object? parameter = null);
}
