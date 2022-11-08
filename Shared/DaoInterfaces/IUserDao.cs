using Shared.Models;

namespace Shared.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsernameAsync(string userName);

    // public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchParameters);
    IEnumerable<User> GetAll();
}