
namespace Posterr.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<AppResult<User>> AddOrUpdateAsync(User user);
        Task<AppResult<User>> GetByIdAsync(Guid id);
        Task<PagedResult<User>> GetPagedAsync(Pagination pagination);
        Task<AppResult<UserFollower>> AddFollower(UserFollower userFollower);
        Task<AppResult<UserFollower>> RemoveFollower(UserFollower userFollower);
    }
}
