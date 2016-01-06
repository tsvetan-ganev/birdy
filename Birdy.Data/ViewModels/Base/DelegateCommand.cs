namespace Birdy.Data.ViewModels.Base
{
    using System;
    using System.Windows.Input;

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> action;

        public DelegateCommand(Action<T> action)
        {
            this.action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action((T)parameter);
        }
    }
}