using Shared.Models;

namespace Shared.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    //Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters);

    Task<IEnumerable<Post>> GetAllAsync();
}