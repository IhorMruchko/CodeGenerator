using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels;

public abstract class GenerationElementViewModel: ViewModel
{
    public RelayedCommand GenerateCommand => new(Generate);

    public RelayedCommand PreviewCommand => new(Preview);

    public RelayedCommand EditCommand => new(Edit);

    public RelayedCommand DeleteCommand => new(Delete);

    public RelayedCommand OpenCommand => new(Open);

    public abstract void Generate(string dir);

    public abstract string GenerateAttributes(int tabIndex);

    public abstract string GenerateFluentApi();

    protected abstract void Preview(object? parameter = null);
    
    protected abstract void Generate(object? parameter = null);

    protected abstract void Edit(object? parameter = null);

    protected abstract void Delete(object? parameter = null);

    protected abstract void Open(object? parameter = null);
}
