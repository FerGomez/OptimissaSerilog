using NUnit.Framework.Internal;
using Optimissa.Serilog;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ErrorTester
{
    public class ConsoleTests
    {

        [Test]
        public async Task Error_ActionSucceeds_LogsSuccessMessages()
        {
            await Serilogger.ProcessError(() =>
            {
                return 99;
            });

            Assert.Pass();
        }

        [Test]
        public async Task Error_ActionThrowsException_LogsExceptionDetails()
        {
            await Serilogger.ProcessError(Func<int> () => { throw new InvalidOperationException("Something went wrong"); });

            Assert.Pass();
        }
    }
}