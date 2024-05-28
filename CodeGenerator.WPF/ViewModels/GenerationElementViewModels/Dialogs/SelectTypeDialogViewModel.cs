using CodeGenerator.WPF.ViewModels.BaseModels;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class SelectTypeDialogViewModel: DialogViewModel, IDirectoryProvider
{
    private string _directory = string.Empty;
    
    public string Directory 
    { 
        get => _directory;
        set
        {
            _directory = value;
            OnPropertyChanged();
        }
    }
}
