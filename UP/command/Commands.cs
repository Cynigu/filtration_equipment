using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UP.command
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameter);
        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
    public class AsyncCommand : AsyncCommandBase
    {
        // Асинхронный эквивалент Action
        private readonly Func<Task> _command;
        public AsyncCommand(Func<Task> command)
        {
            _command = command;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override Task ExecuteAsync(object parameter)
        {
            return _command();
        } 
    }
    public class RelayCommand : ICommand
    {
        // Делегат Action является обобщенным, принимает параметры и возвращает значение void:
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
        // событие Executed прикрепляет обработчик, который будет выполняться при вызове команды.
        // А свойство Command уставливает саму команду, к которой относится обработчик.
        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
