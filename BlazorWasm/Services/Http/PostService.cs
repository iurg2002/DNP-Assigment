using System.Text;
using System.Text.Json;
using Shared.Dtos;
using Shared.Models;

namespace BlazorWasm.Services.Http;

public class PostService : IPostService
{
    private readonly HttpClient client;

    public PostService(HttpClient client)
    {
        this.client = client;
    }

    public async Task CreatePostAsync(PostCreationDto dto)
    {
        string postAsJson = JsonSerializer.Serialize(dto);
        StringContent content = new(postAsJson, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://localhost:7130/post/create", content);
        string responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(responseContent);
        }
    }

    public async Task<IEnumerable<Post>> GetPostsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7130/post/get");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
        //return null;
    }

    public async Task<Post> GetPostById(int postId)
    {
        HttpResponseMessage response = await client.GetAsync($"https://localhost:7130/post/get/{postId}");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }
        
        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
}