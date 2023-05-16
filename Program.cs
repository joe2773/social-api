using AutoMapper;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Domain.Services;
using Domain.Services.Interfaces;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(configuration => {
    configuration.RegisterValidatorsFromAssemblyContaining<UserValidator>();
    configuration.RegisterValidatorsFromAssemblyContaining<PostValidator>();
    configuration.RegisterValidatorsFromAssemblyContaining<LikeValidator>();
    configuration.RegisterValidatorsFromAssemblyContaining<CommentValidator>();
    configuration.ImplicitlyValidateChildProperties = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddDbContext<SocialDbContext>(options =>
{
    options.UseSqlite("Data Source= database.db");
});

// Register your domain services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ICommentService, CommentService>();


var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
