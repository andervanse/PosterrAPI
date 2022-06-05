using Microsoft.EntityFrameworkCore;
using Posterr.Data.Shared;
using Posterr.Domain;
using Posterr.Domain.Interfaces;

namespace Posterr.Repository.Postgresql
{
    public class PostRepository : RepositoryBase<User>, IPostRepository
    {
        private readonly PosterrDbContext _context;

        public PostRepository(PosterrDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<AppResult<Post>> AddPostAsync(Post post)
        {
            var appResult = new AppResult<Post>();

            if (post.Id == Guid.Empty)
            {
                await _context.Posts.AddAsync(post);

                try
                {
                    appResult.Data = post;
                }
                catch (Exception ex)
                {
                    appResult.AddError(ex, "Failed to persist Post.");
                }
            }
            return appResult;
        }

        public async Task<AppResult<Post>> GetByIdAsync(Guid postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            return new AppResult<Post> { Data = post };
        }

        public async Task<PagedResult<Post>> GetPagedAsync(Pagination pagination)
        {
            var pagedResult = new PagedResult<Post>(pagination);

            try
            {
                var userList = await _context.Posts
                                             .Include(x => x.Owner)                                          
                                             .Skip(pagination.Skip)
                                             .Take(pagination.Take)
                                             .ToListAsync();
                pagedResult.DataSet = userList;

            }
            catch (Exception ex)
            {
                pagedResult.AddError(ex, "Failed to retrieve posts.");
            }

            return pagedResult;
        }
    }
}
