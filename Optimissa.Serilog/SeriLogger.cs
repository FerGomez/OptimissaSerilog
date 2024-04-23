using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Optimissa.Serilog
{
    public class SeriLogger
    {
        private readonly Logger _logger;

        public SeriLogger(Logger logger)
        {
            _logger = logger;
        }

        public async Task<TResult> ProcessError<TResult>(
            Func<TResult> action,
            bool throwEx = true,
            [CallerMemberName] string caller = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
                _logger.Information($"Action is executing (line {lineNumber})");
                return action();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Exception in {caller} (line {lineNumber})\n${ex.Message}");

                if (throwEx)
                    throw;
            }   

            return default(TResult);
        }

        public void Write(LogEvent logEvent)
        {
            throw new NotImplementedException();
        }
    }
}
