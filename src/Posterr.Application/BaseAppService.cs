using Microsoft.Extensions.Logging;
using Posterr.Application.Interfaces;
using Posterr.Domain;

namespace Posterr.Application
{
    public abstract class BaseAppService<T> : IAppService<T>
    {
        private readonly ILogger<T> _logger;

        public BaseAppService(ILogger<T> logger)
        {
            _logger = logger;
        }
        public void LogResult(AppResult<T> result)
        {
            if (!result.Success)
            {
                if (result.BusinessErrors != null && result.BusinessErrors.Any())
                    _logger.LogError(String.Join(", ", result.BusinessErrors));

                if (result.InternalErrors != null && result.InternalErrors.Any())
                    _logger.LogError(String.Join(", ", result.InternalErrors));
            }
        }
    }
}
