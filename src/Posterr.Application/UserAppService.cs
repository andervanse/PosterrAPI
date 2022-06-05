
using AutoMapper;
using Microsoft.Extensions.Logging;
using Posterr.Application.DTOs;
using Posterr.Application.Interfaces;
using Posterr.Domain;
using Posterr.Domain.Interfaces;

namespace Posterr.Application
{
    public class UserAppService : BaseAppService<User>, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<User> _logger;

        public UserAppService(
            IUserRepository userRepository,
            IMapper mapper,
            ILogger<User> logger) : base(logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AppResult<UserDto>> SaveAsync(CreateUserDto userDto)
        {
            var resultDto = new AppResult<UserDto>();
            var user = _mapper.Map<User>(userDto);
            var result = await _userRepository.AddOrUpdateAsync(user);

            try
            {
                await _userRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.AddError(ex, "Error to persist user.");
            }

            resultDto.Data = _mapper.Map<UserDto>(result.Data);
            LogResult(result);

            return resultDto;
        }

        public async Task<AppResult<UserDto>> GetByIdAsync(Guid id)
        {
            var result = await _userRepository.GetByIdAsync(id);
            var dto = _mapper.Map<UserDto>(result.Data);
            LogResult(result);
            return new AppResult<UserDto> { Data = dto };
        }

        public async Task<PagedResult<UserDto>> GetPagedAsync(PaginationDto paginationDto)
        {
            var pagination = _mapper.Map<Pagination>(paginationDto);
            var resultDto = new PagedResult<UserDto>(pagination);
            var result = await _userRepository.GetPagedAsync(pagination);
            resultDto.DataSet = _mapper.Map<IEnumerable<UserDto>>(result.DataSet);
            LogResult(result);
            return resultDto;
        }

        public async Task<AppResult<string>> FollowUserAsync(UserFollowerDto userFollowerDto)
        {
            var resultDto = new AppResult<string>();
            var followedResult = await _userRepository.GetByIdAsync(userFollowerDto.UserFollowedId);
            var followerResult = await _userRepository.GetByIdAsync(userFollowerDto.UserFollowerId);
            var followed = followedResult.Data;
            var follower = followerResult.Data;

            if (followed != null && follower != null)
            {
                followed.AddFollower(follower);
                await _userRepository.AddOrUpdateAsync(followed);

                foreach (var userFollower in followed.Followers)
                {
                    await _userRepository.AddFollower(userFollower);                    
                }

                try
                {
                    await _userRepository.SaveChangesAsync();
                    resultDto.Data = "success";
                }
                catch (Exception ex)
                {
                    resultDto.AddError(ex, $"Error to follow user {userFollowerDto.UserFollowedId}.");
                } 
                
            }
            return resultDto;
        }

        public async Task<AppResult<string>> UnfollowUserAsync(UserFollowerDto userFollowerDto)
        {
            var resultDto = new AppResult<string>();
            var followedResult = await _userRepository.GetByIdAsync(userFollowerDto.UserFollowedId);
            var followerResult = await _userRepository.GetByIdAsync(userFollowerDto.UserFollowerId);
            var followed = followedResult.Data;
            var follower = followerResult.Data;

            if (followed != null && follower != null)
            {
                followed.RemoveFollower(follower);
                await _userRepository.AddOrUpdateAsync(followed);

                foreach (var userFollower in followed.Followers)
                {
                    await _userRepository.RemoveFollower(userFollower);
                }

                try
                {
                    await _userRepository.SaveChangesAsync();
                    resultDto.Data = "success";
                }
                catch (Exception ex)
                {
                    resultDto.AddError(ex, $"Error to unfollow user {userFollowerDto.UserFollowedId}.");
                }

            }
            return resultDto;
        }
    }
}
