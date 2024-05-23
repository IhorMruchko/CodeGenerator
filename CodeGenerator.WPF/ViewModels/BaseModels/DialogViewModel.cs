using CodeGenerator.WPF.LIB.ViewModels;
using System;

namespace CodeGenerator.WPF.ViewModels.BaseModels;

public class DialogViewModel : ViewModel
{
    public event Action? DialogSuccess;

    public virtual void ConfirmDialog()
    {
        DialogSuccess?.Invoke();
    }
}
