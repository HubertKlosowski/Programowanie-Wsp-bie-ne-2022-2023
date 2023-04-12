using System.Windows.Input;

namespace ViewModel;

public class RelayCommand : ICommand
{
    private Action<object?> _executeMethod;
    private Func<object?, bool> _canExecuteMethod;

    public RelayCommand(Action<object?> executeMethod, Func<object?, bool> canExecuteMethod)
    {
        _executeMethod = executeMethod;
        _canExecuteMethod = canExecuteMethod;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecuteMethod(parameter);
    }

    public void Execute(object? parameter)
    {
        _executeMethod(parameter);
    }

    public event EventHandler? CanExecuteChanged;
}
