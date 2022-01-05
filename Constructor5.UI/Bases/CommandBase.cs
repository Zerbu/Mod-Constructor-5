using System;
using System.Windows;
using System.Windows.Input;

namespace Constructor5.UI.Bases
{
    public abstract class CommandBase : FrameworkElement, ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public virtual bool CanExecute(object parameter) => true;

        public abstract void Execute(object parameter);
    }
}
