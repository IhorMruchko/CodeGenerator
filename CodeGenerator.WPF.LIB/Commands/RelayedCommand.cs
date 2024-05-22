using System;
using System.Windows.Input;

namespace CodeGenerator.WPF.LIB.Commands;

public class RelayedCommand : ICommand
{
    private readonly Action<object?> _execute;

    private readonly Func<object?, bool>? _canExecute;

    public RelayedCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter)
        => _canExecute?.Invoke(parameter) ?? true;

    public void Execute(object? parameter)
        => _execute(parameter);

}
