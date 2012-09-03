﻿using System;
using System.Windows.Input;

namespace ViewModelFirst
{
    public class RelayCommand : ICommand
    {
        private Action _action;

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }
}