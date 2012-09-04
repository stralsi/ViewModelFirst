using System;
using System.Windows.Input;

namespace ViewModelFirst
{
    public class RelayCommand : ICommand
    {
        private Action _action;
        private bool _canExecute = true;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void SetCanExecute(bool value)
        {
            _canExecute = value;
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
