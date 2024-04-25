using NUnit.Framework.Internal;
using Optimissa.Serilog;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace ErrorTester
{
    public class Tests
    {

        [Test]
        public async Task Fatal_ActionSucceeds_LogsSuccessMessages()
        {
            await Serilogger.ProcessFatal(() =>
            {
                return 99;
            });

            Assert.Pass();
        }

        [Test]
        public async Task Fatal_ActionThrowsException_LogsExceptionDetails()
        {
            await Serilogger.ProcessFatal(Func<int> () => { throw new InvalidOperationException("Something went wrong"); });

            Assert.Pass();
        }

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

        [Test]
        public async Task Verbose_ActionSucceeds_LogsSuccessMessages()
        {
            await Serilogger.ProcessVerbose(() =>
            {
                return 99;
            });

            Assert.Pass();
        }

        [Test]
        public async Task Verbose_ActionThrowsException_LogsExceptionDetails()
        {
            await Serilogger.ProcessVerbose(Func<int> () => { throw new InvalidOperationException("Something went wrong"); });

            Assert.Pass();
        }


        [Test]
        // Verifica que el mensaje de éxito predeterminado se registre correctamente
        public async Task Warning_ActionSucceds_LogsSuccessMessage()
        {
            Func<int> SuccesfulAction = () => { return 23; };
            await Serilogger.ProcessWarning(SuccesfulAction);
        }

        [Test]
        // Verifica que el mensaje de advertencia junto con el mensaje de excepción se registre correctamente
        public async Task Warning_WhenActionThrowsException_LoggerCalledWithWarning()
        {
            Func<int> FailingAction = () => throw new InvalidOperationException("Operacion invalida");
            await Serilogger.ProcessWarning(FailingAction);
        }

    }
}