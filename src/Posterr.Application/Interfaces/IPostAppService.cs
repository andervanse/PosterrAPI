using Posterr.Application.DTOs;
using Posterr.Domain;

namespace Posterr.Application.Interfaces
{
    public interface IPostAppService : IAppService<Post>
    {
        Task<AppResult<PostDto>> GetByIdAsync(Guid postId);
        Task<PagedResult<PostDto>> GetPagedAsync(PaginationDto pagination);
        Task<AppResult<PostDto>> AddPostAsync(CreatePostDto post);
    }
}
