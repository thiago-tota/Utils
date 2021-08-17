using Newtonsoft.Json.Linq;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Tota.SharedKernel.Test
{
    class CustomEventArgs : EventArgs
    {
        public string Msg { get; }
        public int Value { get; }

        public CustomEventArgs(string msg, int value)
        {
            Msg = msg;
            Value = value;
        }
    }

    public class Delegates
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public Delegates(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        Action<string, int> OnActionTriggered;
        Func<int, int, int> OnFuncTriggered;
        Predicate<int> OnPredicateTriggered;
        delegate int OnCustomDelegate(int arg1, int arg2);

        event EventHandler<CustomEventArgs> OnEventHandlerTriggered;

        [Fact]
        private void ActionDelegateAnonymousMethod()
        {
            OnActionTriggered = (msg, value) => { _testOutputHelper.WriteLine($"{msg}: {value}"); };
            OnActionTriggered("Value received", 10);
        }

        [Fact]
        private void ActionDelegateDeclaredMethod()
        {
            OnActionTriggered = WriteMessage;
            OnActionTriggered("Value received", 20);
        }

        [Fact]
        private void FuncDelegateAnonymousMethod()
        {
            OnFuncTriggered = (arg1, arg2) => { return arg1 + arg2; };
            OnFuncTriggered(10, 10);
        }

        [Fact]
        private void EventListeners()
        {

        }

        private void WriteMessage(string msg, int value)
        {
            _testOutputHelper.WriteLine($"{msg}: {value}");
        }
    }
}
