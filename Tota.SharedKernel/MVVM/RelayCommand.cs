using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tota.SharedKernel.MVVM
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        readonly Action _targetExecuteMethod;
        readonly Func<bool> _targetCanExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                return _targetCanExecuteMethod();
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            _targetExecuteMethod?.Invoke();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        readonly Action<T> _targetExecuteMethod;
        readonly Func<T, bool> _targetCanExecuteMethod;

        public RelayCommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object? parameter)
        {
            if (parameter != null)
                _targetExecuteMethod?.Invoke((T)parameter);
        }
    }

    public class RelayAsyncCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        readonly Func<Task> _targetExecuteMethod;
        readonly Func<bool> _targetCanExecuteMethod;

        public RelayAsyncCommand(Func<Task> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayAsyncCommand(Func<Task> executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object? parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                return _targetCanExecuteMethod();
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            _targetExecuteMethod?.Invoke();
        }
    }

    public class RelayAsyncCommand<T> : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        readonly Func<T, Task> _targetExecuteMethod;
        readonly Func<T, bool> _targetCanExecuteMethod;

        public RelayAsyncCommand(Func<T, Task> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayAsyncCommand(Func<T, Task> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object? parameter)
        {
            if (_targetCanExecuteMethod != null)
            {
                T tparm = (T)parameter;
                return _targetCanExecuteMethod(tparm);
            }
            if (_targetExecuteMethod != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object? parameter)
        {
            if (parameter != null)
                _targetExecuteMethod?.Invoke((T)parameter);
        }
    }
}
