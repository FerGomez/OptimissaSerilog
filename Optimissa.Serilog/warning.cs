using Serilog;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Optimissa.Serilog
{
    public class WarningService
    {
        private readonly ILogger _logger;



        public WarningService()
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .CreateLogger();
        }
  
        public async Task WarningLog<TResult>(Func<TResult> action, string message = "", bool throwException = true,
                               [CallerMemberName] string method = null,
                               [CallerLineNumber] int lineNumber = 0)
        {
            try
            {   
                _logger.Warning($" Warning  con el metodo '{method}' en la linea  {lineNumber}");
                var  result = action();
            }
            catch (Exception ex)
            {
        
                    _logger.Warning($"Warning en la linea  {lineNumber} del metodo'{method}': {message} (Excepcion: {ex.Message})");

            }
        }
    }
}
