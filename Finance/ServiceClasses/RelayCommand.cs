using System;
using System.Windows.Input;

namespace Finance.ServiceClasses
{
    public class RelayCommand : ICommand
    {
        private readonly Action _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;

        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator = null)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        public bool CanExecute(object parameter)=> _canExecuteEvaluator == null || _canExecuteEvaluator.Invoke();
        public void Execute(object parameter) => _methodToExecute.Invoke();

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<object> _methodToExecute;
        private readonly Func<bool> _canExecuteEvaluator;

        public RelayCommand(Action<object> methodToExecute, Func<bool> canExecuteEvaluator = null)
        {
            _methodToExecute = methodToExecute;
            _canExecuteEvaluator = canExecuteEvaluator;
        }

        public bool CanExecute(object parameter) => _canExecuteEvaluator == null || _canExecuteEvaluator.Invoke();
        public void Execute(object parameter) => _methodToExecute.Invoke(parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}