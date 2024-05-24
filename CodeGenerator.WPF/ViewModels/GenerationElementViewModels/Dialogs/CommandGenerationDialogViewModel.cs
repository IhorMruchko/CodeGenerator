using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class CommandGenerationDialogViewModel: DialogViewModel
{
    public CommandGenerationItem Item { get; set; } = new();

    public string Command
    {
        get => Item.Command;
        set
        {
            Item.Command = value;
            OnPropertyChanged();
        }
    }

    public string Class
    {
        get => Item.Class;
        set
        {
            Item.Class = value;
            OnPropertyChanged();
        }
    }

    public string? Help
    {
        get => Item.Help;
        set
        {
            Item.Help = value;
            OnPropertyChanged();
        }
    }
}
