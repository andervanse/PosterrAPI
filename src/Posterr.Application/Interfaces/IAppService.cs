using Posterr.Domain;

namespace Posterr.Application.Interfaces
{
    public interface IAppService<T>
    {
        void LogResult(AppResult<T> result);
    }
}