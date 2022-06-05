
namespace Posterr.Domain.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<PagedResult<Post>> GetPagedAsync(Pagination pagination);
        Task<AppResult<Post>> AddPostAsync(Post post);
        Task<AppResult<Post>> GetByIdAsync(Guid postId);
    }
}
