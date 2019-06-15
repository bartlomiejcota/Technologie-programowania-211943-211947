using System;
using System.Windows.Input;

namespace WarstwaPrezentacji.ViewModel
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action _action;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}