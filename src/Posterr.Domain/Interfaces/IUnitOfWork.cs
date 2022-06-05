using Posterr.Domain;

namespace Posterr.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<AppResult<int>> SaveChangesAsync();
    }
}