using Posterr.Application.DTOs;
using Posterr.Domain;

namespace Posterr.Application.Interfaces
{
    public interface IUserAppService : IAppService<User>
    {
        Task<AppResult<UserDto>> GetByIdAsync(Guid userId);
        Task<PagedResult<UserDto>> GetPagedAsync(PaginationDto pagination);
        Task<AppResult<UserDto>> SaveAsync(CreateUserDto user);
        Task<AppResult<string>> FollowUserAsync(UserFollowerDto userFollower);
        Task<AppResult<string>> UnfollowUserAsync(UserFollowerDto userFollower);
    }
}
