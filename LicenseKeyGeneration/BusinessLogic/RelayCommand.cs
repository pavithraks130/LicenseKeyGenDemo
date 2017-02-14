using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LicenseKeyGeneration.BusinessLogic
{
    class RelayCommand : ICommand
    {
        private Action<object> _action;
        private Func<object, bool> _canexecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _action = execute;
            _canexecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canexecute != null)
                return _canexecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
                _action(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
