using AutoMapper;
using Posterr.Application.DTOs;
using Posterr.Domain;

namespace Posterr.Application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Pagination, PaginationDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();

            CreateMap<UserPostsPerDay, UserPostsPerDayDto>().ReverseMap()
                .ForMember(o => o.UserId, c => c.Ignore());

            CreateMap<UserSummary, UserSummaryDto>().ReverseMap()
                .ForMember(o => o.UserId, c => c.Ignore());

            CreateMap<Post, PostDto>()
                .ForMember(o => o.UserOwnerId, c => c.MapFrom(d => d.UserId))
                .ReverseMap()
                .ForMember(o => o.UserId, c => c.MapFrom(d => d.UserOwnerId));

            CreateMap<CreatePostDto, Post>()
                .ForMember(o => o.UserId, c => c.MapFrom(d => d.UserOwnerId));
        }
    }
}
