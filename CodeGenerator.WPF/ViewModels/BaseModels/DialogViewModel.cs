using CodeGenerator.WPF.LIB.Commands;
using CodeGenerator.WPF.LIB.ViewModels;

namespace CodeGenerator.WPF.ViewModels.BaseModels;

public class DialogViewModel : ViewModel
{
    public RelayedCommand ConfirmDialogCommand => new(ConfirmDialog);

    private bool _hasValue;

    public bool HasValue
    {
        get => _hasValue;
        set
        {
            if (_hasValue == value) return;

            _hasValue = value;
            OnPropertyChanged();
        }
    }

    protected virtual void ConfirmDialog(object? parameter)
    {
        HasValue = true;
    }
}
