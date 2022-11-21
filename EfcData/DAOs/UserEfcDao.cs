using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared.DaoInterfaces;
using Shared.Models;

namespace EfcData.DAOs;

public class UserEfcDao : IUserDao
{
    private readonly PostContext context;

    public UserEfcDao(PostContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existingUser = context.Users.FirstOrDefault(u => u.Username.ToLower().Equals(userName.ToLower()));
        return existingUser;
    }

    public IEnumerable<User> GetAll()
    {
        IEnumerable<User> users = context.Users.AsEnumerable();
        return users;
    }
}