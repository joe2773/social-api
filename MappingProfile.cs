using AutoMapper;
using Dtos;
using Data.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserRequestDto>();
        CreateMap<UserRequestDto, User>();
        CreateMap<Like, LikeRequestDto>();
        CreateMap<LikeRequestDto, Like>();
        CreateMap<Comment, CommentRequestDto>();
        CreateMap<CommentRequestDto, Comment>();
        CreateMap<Post, PostRequestDto>();
        CreateMap<PostRequestDto, Post>();

        CreateMap<User, UserResponseDto>();
        CreateMap<UserResponseDto, User>();
        CreateMap<Like, LikeResponseDto>();
        CreateMap<LikeResponseDto, Like>();
        CreateMap<Comment, CommentResponseDto>();
        CreateMap<CommentResponseDto, Comment>();
        CreateMap<Post, PostResponseDto>();
        CreateMap<PostResponseDto, Post>();
        // Add more mappings as needed
    }
}
