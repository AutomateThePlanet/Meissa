using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Microsoft.Extensions.Logging;

namespace Meissa.Server.Services
{
    public class EmptyDistributedLogger : IDistributeLogger
    {
        private readonly ILogger<EmptyDistributedLogger> _logger;
        public EmptyDistributedLogger(ILogger<EmptyDistributedLogger> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteWithLoggingAsync(Action action, string exceptionMessage = null, bool shouldRethrowException = true)
        {
        }

        public async Task LogErrorAsync(string message, Exception ex)
        {
        }

        public async Task LogInfoAsync(string message)
        {
        }
    }
}
