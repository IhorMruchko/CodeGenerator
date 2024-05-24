using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.ViewModels.BaseModels;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CodeGenerator.WPF.ViewModels.GenerationElementViewModels.Dialogs;

public class SelectTypeDialogViewModel: DialogViewModel
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

    public RelayedCommand OpenDirectoryDialogCommand => new(OpenDirectoryDialog);

    private void OpenDirectoryDialog(object? parameter)
    {
        var directoryDialog = new CommonOpenFileDialog()
        {
            IsFolderPicker = true,
            InitialDirectory = parameter as string
        };

        if (directoryDialog.ShowDialog() != CommonFileDialogResult.Ok) return;
        Directory = directoryDialog.FileName!;
    }
}
