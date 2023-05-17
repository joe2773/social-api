using AutoMapper;
using Dtos;
using Data.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        CreateMap<Like, LikeRequestDto>();
        CreateMap<LikeRequestDto, Like>();
        CreateMap<Comment, CommentRequestDto>();
        CreateMap<CommentRequestDto, Comment>();
        CreateMap<Post, PostRequestDto>();
        CreateMap<PostRequestDto, Post>();
        // Add more mappings as needed
    }
}
