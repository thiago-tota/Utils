namespace Tota.SharedKernel.Test.DiPerformanceComparison
{
    internal class Example
    {
        private IExampleInjected _exampleInjected;
        public Example(IExampleInjected exampleInjected)
        {
            _exampleInjected = exampleInjected;
        }
    }
}
