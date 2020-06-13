﻿using System;
using System.Windows.Input;

namespace Marketo.WPF.MaterialDesign.Commands
{
    public class CancelCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
