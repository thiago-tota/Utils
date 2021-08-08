using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tota.SharedKernel.MVVM
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null, bool checkEquals = true)
        {

            if (checkEquals && Equals(member, val)) return;

            member = val;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //The Dispose should be implemented on each class derived from BindableBase 
        //and release all resources.
        public abstract void Dispose();

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
