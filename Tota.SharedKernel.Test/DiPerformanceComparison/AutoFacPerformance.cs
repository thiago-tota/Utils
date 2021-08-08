using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Tota.SharedKernel.Test.DiPerformanceComparison
{
    public class AutoFacPerformance
    {
        private readonly ITestOutputHelper _outputHelper;

        public AutoFacPerformance(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void RegisterType()
        {

        }
    }
}
