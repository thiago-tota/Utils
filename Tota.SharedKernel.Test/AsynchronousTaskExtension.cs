using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Tota.SharedKernel.Asynchronous;
using Xunit;

namespace Tota.SharedKernel.Test
{
    public class AsynchronousTaskExtension
    {
        private const string COMPLETED_CALLBACK_MESSAGE = "Task has been completed.";
        private const string ERROR_CALLBACK_MESSAGE = "Task has throw an error:";
        private const int TIMEOUT = 5000;

        private string _awaitResult;

        [Fact]
        public void WhenTaskCompletedSuccessfulyThenPass()
        {
            DoSomethingReturnTask().Await(CompletedTaskCallback, ErrorTaskCallback);

            AwaitTaskCompletion().ContinueWith(_ =>  Debug.WriteLine("AwaitTaskCompletion completed"));

            Assert.Equal(COMPLETED_CALLBACK_MESSAGE, _awaitResult);
        }

        [Fact]
        public void WhenTaskCompletedSuccessfulyThenPassUsingTPL()
        {
            var task = Task.Run(() => DoSomethingReturnTask());

            task.ContinueWith(_ => CompletedTaskCallback(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(ex => ErrorTaskCallback(ex.Exception), TaskContinuationOptions.OnlyOnFaulted);

            AwaitTaskCompletion().ContinueWith(_ => Debug.WriteLine("AwaitTaskCompletion completed"));

            Assert.Equal(COMPLETED_CALLBACK_MESSAGE, _awaitResult);
        }

        [Fact]
        public void WhenTaskCompletedSuccessfulyThenGetReturnedData()
        {
            DoSomethingReturnTaskOfT().Await(CompletedTaskCallback, ErrorTaskCallback);

            AwaitTaskCompletion().ContinueWith(_ => Debug.WriteLine("AwaitTaskCompletion completed"));

            Assert.Equal(COMPLETED_CALLBACK_MESSAGE, _awaitResult);
        }

        [Fact]
        public void WhenCallTaskThrowExceptionThenPass()
        {
            DoSomethingThrowException().Await(CompletedTaskCallback, ErrorTaskCallback);

            AwaitTaskCompletion().ContinueWith(_ => Debug.WriteLine("AwaitTaskCompletion completed"));

            Assert.Contains(ERROR_CALLBACK_MESSAGE, _awaitResult);
        }

        [Fact]
        public void WhenCallTaskThrowExceptionThenPassUsingTPL()
        {
            var task = Task.Run(async () => await DoSomethingThrowException());

            task.ContinueWith(_ => CompletedTaskCallback(), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(ex => ErrorTaskCallback(ex.Exception), TaskContinuationOptions.OnlyOnFaulted);
            AwaitTaskCompletion().ContinueWith(_ => Debug.WriteLine("AwaitTaskCompletion completed"));

            Assert.Contains(ERROR_CALLBACK_MESSAGE, _awaitResult);
        }

        private void CompletedTaskCallback()
        {
            _awaitResult = $"{COMPLETED_CALLBACK_MESSAGE}";
        }

        private void CompletedTaskCallback(string message)
        {
            _awaitResult = message;
        }

        private void ErrorTaskCallback(Exception ex)
        {
            _awaitResult = $"{ERROR_CALLBACK_MESSAGE} {ex}";
        }

        private async Task DoSomethingReturnTask()
        {
            await Task.Delay(3000);
        }

        private async Task<string> DoSomethingReturnTaskOfT()
        {
            await Task.Delay(3000);
            return await Task.FromResult(COMPLETED_CALLBACK_MESSAGE);
        }

        private async Task DoSomethingThrowException()
        {
            await Task.Delay(3000);
            throw new Exception(ERROR_CALLBACK_MESSAGE);
        }

        private async Task AwaitTaskCompletion(/*CancellationToken cancellationToken*/)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (_awaitResult == default && stopwatch.ElapsedMilliseconds < TIMEOUT /*&& cancellationToken.IsCancellationRequested == false*/)
            {
                await Task.Delay(1000);
            }
            stopwatch.Stop();
        }

        private async Task LongwaitTaskCompletion(CancellationToken cancellationToken)
        {
            await Task.Delay(60000, cancellationToken);
        }
    }
}
