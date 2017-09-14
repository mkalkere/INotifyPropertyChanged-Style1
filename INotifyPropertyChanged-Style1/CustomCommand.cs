using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace INotifyPropertyChanged_Style1
{
    public class CustomCommand : ICommand
    {
        private Action<object> execute;
        private Predicate<object> canExecute;
        private ICommand click;
        private Func<object, bool> canClick;

        public CustomCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public CustomCommand(ICommand click, Func<object, bool> canClick)
        {
            this.click = click;
            this.canClick = canClick;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
