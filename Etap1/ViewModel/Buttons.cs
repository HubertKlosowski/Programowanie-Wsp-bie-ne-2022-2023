using System.Windows.Input;
using Model;

namespace ViewModel;

public class Buttons : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        // Do something
    }
}