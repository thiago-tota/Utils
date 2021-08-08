using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tota.SharedKernel.Test.DiPerformanceComparison
{
    public class TinyIoCPerformance
    {
        private readonly ITestOutputHelper _outputHelper;

        public TinyIoCPerformance(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
    }
}
