using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CodeGenerator.WPF.LIB.ViewModels;

public abstract class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? callerName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
}
