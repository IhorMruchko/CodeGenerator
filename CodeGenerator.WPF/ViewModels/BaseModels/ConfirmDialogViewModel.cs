using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.Views;

namespace CodeGenerator.WPF.ViewModels.BaseModels;

public class ConfirmDialogViewModel : DialogViewModel
{
    private string? _confirmationText;
    
    public string? ConfirmationText { 
        get => _confirmationText; 
        set
        {
            _confirmationText = value;
            OnPropertyChanged();
        } 
    }

    public object? Target { get; set; }

    public RelayedCommand ConfirmActionCommand => new(ConfirmAction);

    private void ConfirmAction(object? parameter = null)
    {
        HasValue = true;
        
        if (parameter is not MainWindow mv) return;
        
        mv.CloseDialogWindow(true);
    }
}
