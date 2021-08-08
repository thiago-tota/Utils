using System;
using System.Threading.Tasks;

namespace Tota.SharedKernel.MVVM
{
    //Use this class in the App level to standarize events and/or methods that are common among the ViewModels.
    public abstract class BaseViewModel : BindableBase
    {
        //Methods for ilustration purpouse.
        public abstract Task RefreshDataAsync();

        public async Task<T> ExecuteWithLoadingControlAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task ExecuteWithLoadingControlAsync(Func<Task> func)
        {
            try
            {
                await func?.Invoke();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
