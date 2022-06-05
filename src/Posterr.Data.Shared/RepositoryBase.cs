using Microsoft.EntityFrameworkCore;
using Posterr.Domain;
using Posterr.Domain.Interfaces;

namespace Posterr.Data.Shared
{
    public abstract class RepositoryBase<T> : IUnitOfWork, IRepository<T> where T : EntityBase
    {
        public DbContext _ctx;

        public RepositoryBase(DbContext dbContext)
        {
            _ctx = dbContext;
        }

        public async Task<AppResult<int>> SaveChangesAsync()
        {
            var appResult = new AppResult<int>();

            try
            {
                appResult.Data = await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                appResult.AddError(ex, "Failed to apply to the database.");
            }

            return appResult;
        }
    }
}