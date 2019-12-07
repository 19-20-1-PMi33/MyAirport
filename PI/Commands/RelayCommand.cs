using System;
using System.Windows.Input;

namespace PI.Commands
{
    /// <summary>
    /// Клас RelayCommand
    /// Цей клас реалізує інтерфейс ICommand,завдяки якому ми можемо направляти виклики до ViewModel. 
    /// Ключовим тут є метод Execute(). 
    /// </summary>
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }
        /// <summary>
        /// Даний метод  получає параметр і виконує дію, передану через конструктор.
        /// </summary>
        /// <param name="parameter">пений параметр</param>
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

}
