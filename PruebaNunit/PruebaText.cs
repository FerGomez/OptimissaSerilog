using NUnit.Framework;
using Optimissa.Serilog;
using Serilog;
using System;

namespace PruebaNunit
{
    public class Tests
    {

        private WarningService _logger;

        [SetUp]

        public void Setup()
        {
            _logger = new WarningService();
        }

        [Test]
        // Verifica que el mensaje de �xito predeterminado se registre correctamente
        public async Task Warning_ActionSucceds_LogsSuccessMessage()
        {
            Func<int> SuccesfulAction = () => { return 23; };
            await _logger.WarningLog(SuccesfulAction);
        }

        [Test]
        // Verifica que el mensaje de advertencia junto con el mensaje de excepci�n se registre correctamente
        public async Task Warning_WhenActionThrowsException_LoggerCalledWithWarning()
        {
            Func<int> FailingAction = () => throw new InvalidOperationException("Operacion invalida");  
            await _logger.WarningLog(FailingAction);
        }
    

    }
}
