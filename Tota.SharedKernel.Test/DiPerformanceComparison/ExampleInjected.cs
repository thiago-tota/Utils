using System;

namespace Tota.SharedKernel.Test.DiPerformanceComparison
{
    internal class ExampleInjected : IExampleInjected
    {
        private int MyProperty1 { get; set; } = 37;
        private string MyProperty2 { get; set; } = "Thiago";
        private DateTime MyProperty3 { get; set; } = DateTime.Now;

        public int GetMyProperty1()
        {
            return MyProperty1;
        }

        public string GetMyProperty2()
        {
            return MyProperty2;
        }

        public DateTime GetMyProperty3()
        {
            return MyProperty3;
        }
    }
}
