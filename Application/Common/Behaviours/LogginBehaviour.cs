using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    internal class LogginBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LogginBehaviour<TRequest, TResponse>> _logger;
        public LogginBehaviour(ILogger<LogginBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting request {@RequestName}, {@DateTimeNow}, {@Request}",
                typeof(TRequest).Name, DateTime.Now, request);

            var result = await next();

            _logger.LogInformation("Request failure {@RequestName}, {@DateTime} {@Response},",
                    typeof(TRequest).Name, DateTime.Now, result);

            return result;
        }
    }
}
