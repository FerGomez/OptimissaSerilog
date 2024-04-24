using NUnit.Framework.Internal;
using Optimissa.Serilog;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ErrorTester
{
    public class ConsoleTests
    {

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public async Task Error_ActionSucceeds_LogsSuccessMessages()
        {
            await SeriLogger.ProcessError(() =>
            {
                return 2;
            });

            Assert.Pass();
        }

        [Test]
        public async Task Error_ActionThrowsException_LogsExceptionDetails()
        {
            await SeriLogger.ProcessError(Func<int> () => { throw new InvalidOperationException("test"); });

            Assert.Pass();
        }
    }
}