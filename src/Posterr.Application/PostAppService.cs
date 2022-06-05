using AutoMapper;
using Microsoft.Extensions.Logging;
using Posterr.Application.DTOs;
using Posterr.Application.Interfaces;
using Posterr.Domain;
using Posterr.Domain.Interfaces;

namespace Posterr.Application
{
    public class PostAppService : BaseAppService<Post>, IPostAppService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostAppService(
            IPostRepository postRepository,
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<Post> logger) : base(logger)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<AppResult<PostDto>> AddPostAsync(CreatePostDto postDto)
        {
            var resultDto = new AppResult<PostDto>();
            var post = _mapper.Map<Post>(postDto);
            var resultUser = await _userRepository.GetByIdAsync(post.UserId);

            if (resultUser.Data != null)
            {
                resultUser.Data.PublishPost(post);
                var userResult = await _userRepository.AddOrUpdateAsync(resultUser.Data);

                var postResult = new AppResult<Post> 
                { 
                    Data = userResult?.Data?.Posts.FirstOrDefault() 
                };
                
                try
                {
                    await _postRepository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    postResult.AddError(ex, "Error to persist new post.");
                }

                resultDto.Data = _mapper.Map<PostDto>(post);
                LogResult(postResult);
            }

            return resultDto;
        }

        public async Task<AppResult<PostDto>> GetByIdAsync(Guid postId)
        {
            var result = await _postRepository.GetByIdAsync(postId);
            var postDto = _mapper.Map<PostDto>(result.Data);
            return new AppResult<PostDto> {  Data = postDto };
        }

        public async Task<PagedResult<PostDto>> GetPagedAsync(PaginationDto paginationDto)
        {
            var pagination = _mapper.Map<Pagination>(paginationDto);
            var resultDto = new PagedResult<PostDto>(pagination);
            var result = await _postRepository.GetPagedAsync(pagination);
            resultDto.DataSet = _mapper.Map<IEnumerable<PostDto>>(result.DataSet);
            LogResult(result);
            return resultDto;
        }

    }
}
