using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DaoInterfaces;
using Shared.Models;

namespace EfcData.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly PostContext context;

    public PostEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Author).AsQueryable();
        

        List<Post> result = await query.ToListAsync();
        return result;
        // IEnumerable<Post> posts = context.Posts.AsEnumerable();
        // return posts;
    }
}