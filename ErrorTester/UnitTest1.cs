using NUnit.Framework.Internal;
using Optimissa.Serilog;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ErrorTester
{
    public class Tests
    {
        private SeriLogger _logger;


        [SetUp]
        public void SetUp()
        {
            _logger = new SeriLogger(new LoggerConfiguration().WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error).CreateLogger());
        }

        [Test]
        public async Task Error_ActionSucceeds_LogsSuccessMessages()
        {
            await _logger.ProcessError(() =>
            {
                return 2;
            });

            Assert.Pass();
        }

        [Test]
        public async Task Error_ActionThrowsException_LogsExceptionDetails()
        {
            await _logger.ProcessError(Func<int> () => { throw new InvalidOperationException("test"); });

            Assert.Pass();
        }
    }
}