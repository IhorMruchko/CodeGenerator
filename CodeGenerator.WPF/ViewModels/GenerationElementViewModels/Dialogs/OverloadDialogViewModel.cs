using CodeGenerator.WPF.Models.GenerationItems;
using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class OverloadDialogViewModel : DialogViewModel
{
    public OverloadModel Item { get; set; } = new();

    public string MethodName
    {
        get => Item.MethodName;
        set
        {
            Item.MethodName = value;
            OnPropertyChanged();
        }
    } 

    public string Help
    {
        get => Item.Help;
        set
        {
            Item.Help = value;
            OnPropertyChanged();
        }
    }

    public string MethodContent
    {
        get => Item.MethodContent;
        set
        {
            Item.MethodContent = value;
            OnPropertyChanged();
        }
    }
}
