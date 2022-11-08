using Shared.DaoInterfaces;
using Shared.Models;

namespace FileData.DAOs;


public class UserFileDao : IUserDao
{
    private readonly FileContext context;

    public UserFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<User> CreateAsync(User user)
    {
        
        context.Users.Add(user);
        context.SaveChanges();

        return Task.FromResult(user);
    }

    public Task<User?> GetByUsernameAsync(string userName)
    {
      
        User? existing = context.Users.FirstOrDefault(u => u.Username.Equals(userName, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(existing);
    }

    public IEnumerable<User> GetAll()
    {
        return context.Users; 
    }


    // public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters)
    // {
    //     IEnumerable<User> users = context.Users.AsEnumerable();
    //     if (searchParameters.UsernameContains != null)
    //     {
    //         users = context.Users.Where(u => u.UserName.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
    //     }
    //
    //     return Task.FromResult(users);
    // }
}