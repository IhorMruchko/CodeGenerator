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
}
