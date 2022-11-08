using Shared.Dtos;
using Shared.Models;

namespace BlazorWasm.Services;

public interface IPostService
{
    public Task CreatePostAsync(PostCreationDto dto);
    public Task<IEnumerable<Post>> GetPostsAsync();


    public Task<Post> GetPostById(int postId);
}