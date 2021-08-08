using System;
using System.Threading.Tasks;

namespace Tota.SharedKernel.Asynchronous
{
    public static class TaskExtension
    {
        public static async void Await(this Task task, Action completedCallback, Action<Exception> errorCallback)
        {
            try
            {
                await task.ConfigureAwait(true);
                completedCallback?.Invoke();
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }

        public static async void Await<T>(this Task<T> task, Action<T> completedCallback, Action<Exception> errorCallback)
        {
            try
            {
                var result = await task.ConfigureAwait(true);
                completedCallback?.Invoke(result);
            }
            catch (Exception ex)
            {
                errorCallback?.Invoke(ex);
            }
        }
    }
}
