using AutoMapper;
using Dtos;
using Data.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserRequestDto>();
        CreateMap<UserRequestDto, User>();
        CreateMap<Like, LikeDto>();
        CreateMap<LikeDto, Like>();
        CreateMap<Comment, CommentDto>();
        CreateMap<CommentDto, Comment>();
        CreateMap<Post, PostDto>();
        CreateMap<PostDto, Post>();
        // Add more mappings as needed
    }
}
