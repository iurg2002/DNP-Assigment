using System.ComponentModel.DataAnnotations;
using Shared.DaoInterfaces;
using Shared.Models;

namespace WebApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserDao userDao;

    public AuthService(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    // private IList<User> users = new List<User>
    // {
    //     new User
    //     {
    //         Age = 36,
    //         Email = "trmo@via.dk",
    //         Name = "Troels Mortensen",
    //         Password = "onetwo3FOUR",
    //         Role = "Teacher",
    //         Username = "trmo"
    //
    //     },
    //     new User
    //     {
    //         Age = 34,
    //         Email = "jakob@gmail.com",
    //         Name = "Jakob Rasmussen",
    //         Password = "password",
    //         Role = "Student",
    //         Username = "jknr"
    //     }
    // };

    public Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = userDao.GetAll().FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingUser);
    }

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        
        // IEnumerable<User> users = userDao.GetAll();
        // // check if username already exists in users list
        // User? existingUser = users.FirstOrDefault(u => u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));
        // if (existingUser != null)
        // {
        //     throw new ValidationException("Username already exists");
        // }
        
    
        // Do more user info validation here
        
        // save to persistence instead of list
        userDao.CreateAsync(user);
        
        //users.Add(user);
        
        return Task.CompletedTask;
    }

    public IEnumerable<User> GetUsers()
    {
        return userDao.GetAll();
    }
}