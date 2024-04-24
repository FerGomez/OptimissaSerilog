using System.Runtime.CompilerServices;
using Serilog;

namespace Optimissa.Serilog
{
    public class Verbose
    {
        private readonly ILogger _logger;

        public Verbose() 
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

        }

        public async Task<TResult> VerboseLog<TResult>(Func<TResult> action, bool throwEx = true,
                              [CallerMemberName] string caller = null
                            , [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                action();

            }catch (Exception ex)
            {
                _logger.Error(ex, $"Error ocurred in method '{caller}' at line {lineNumber}: {ex.Message}");
                if (throwEx)
                    throw;
            }
            
            return default(TResult);

            
        }
    }
}
