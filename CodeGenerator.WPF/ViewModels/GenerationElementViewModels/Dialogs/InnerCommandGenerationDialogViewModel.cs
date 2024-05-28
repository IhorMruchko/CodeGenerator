using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class InnerCommandGenerationDialogViewModel: DialogViewModel
{
    public InnerCommandModel Source { get; set; } = new();

    public string Command
    {
        get => Source.Command;
        set
        {
            Source.Command = value;
            OnPropertyChanged();
        }
    }

    public string Class
    {
        get => Source.Class;
        set
        {
            Source.Class = value;
            OnPropertyChanged();
        }
    }

    public string? Help
    {
        get => Source.Help;
        set
        {
            Source.Help = value;
            OnPropertyChanged();
        }
    }
}
