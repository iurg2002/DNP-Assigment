using Shared.DaoInterfaces;
using Shared.Models;

namespace FileData.DAOs;



public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int id = 1;
        if (context.Posts.Any())
        {
            id = context.Posts.Max(t => t.Id);
            id++;
        }

        post.Id = id;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAllAsync()
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        return Task.FromResult(posts);
    }

    // public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    // {
    //     IEnumerable<Post> posts = context.Posts.AsEnumerable();
    //     if (searchParameters.TitleContains != null)
    //     {
    //         posts = posts.Where(p => p.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
    //     }
    //     if (!string.IsNullOrEmpty(searchParameters.Owner))
    //     {
    //         posts =  posts.Where(p => p.Owner.UserName.Contains(searchParameters.Owner, StringComparison.OrdinalIgnoreCase));
    //     }
    //     return Task.FromResult(posts);
    // }
}