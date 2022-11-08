using Shared.Dtos;
using Shared.Models;

namespace WebApi.Services;

public interface IPostService
{
    Task CreatePost(PostCreationDto post);
    Task<IEnumerable<Post>> GetPosts();

    Task<Post> GetPostById(int id);

}