using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Email;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Optimissa.Serilog
{
    public class Serilogger
    {

        private static readonly ILogger _logger;

        static Serilogger()
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
                .Build();


            _logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

        }

        public static async Task<TResult> ProcessError<TResult>(
            Func<TResult> action,
            bool throwEx = true,
            [CallerMemberName] string caller = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            try
            {
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

    }
}
