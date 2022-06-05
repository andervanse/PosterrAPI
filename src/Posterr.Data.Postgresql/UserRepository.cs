using Microsoft.EntityFrameworkCore;
using Posterr.Data.Shared;
using Posterr.Domain;
using Posterr.Domain.Interfaces;

namespace Posterr.Repository.Postgresql
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly PosterrDbContext _context;

        public UserRepository(PosterrDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppResult<UserFollower>> AddFollower(UserFollower userFollower)
        {
            var appResult = new AppResult<UserFollower>();
            await _context.UserFollowers.AddAsync(userFollower);
            appResult.Data = userFollower;
            return appResult;
        }
        public Task<AppResult<UserFollower>> RemoveFollower(UserFollower userFollower)
        {
            var appResult = new AppResult<UserFollower>();
            _context.UserFollowers.Remove(userFollower);
            appResult.Data = userFollower;
            return Task.FromResult(appResult);
        }

        public async Task<AppResult<User>> AddOrUpdateAsync(User user)
        {
            var appResult = new AppResult<User>();   
            
            if (user.Id == Guid.Empty)
            {
                await _context.Users.AddAsync(user);
            }
            else
            {
                _context.Users.Update(user);
            }

            try
            {             
                appResult.Data = user;
            }
            catch (Exception ex)
            {
                appResult.AddError(ex, "Failed to persist user.");
            }

            return appResult;
        }

        public async Task<AppResult<User>> GetByIdAsync(Guid id)
        {
            var appResult = new AppResult<User>();

            try
            {
                var persistedUser = await _context.Users
                                              .Include(x => x.Summary)
                                              .Include(x => x.TodayPosts)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync(x => x.Id == id);

                appResult.Data = persistedUser;
            }
            catch (Exception ex)
            {
                appResult.AddError(ex, $"Failed to retrieve user id {id}");
            }

            return appResult;
        }

        public async Task<PagedResult<User>> GetPagedAsync(Pagination pagination)
        {
            var pagedResult = new PagedResult<User>(pagination);

            try
            {
                var userList = await _context.Users
                                             .Include(x => x.Summary)
                                             .Include(x => x.TodayPosts)
                                             .Skip(pagination.Skip)
                                             .Take(pagination.Take)
                                             .ToListAsync();
                pagedResult.DataSet = userList;

            }
            catch (Exception ex)
            {
                pagedResult.AddError(ex, "Failed to persist user.");
            }

            return pagedResult;
        }
    }
}
