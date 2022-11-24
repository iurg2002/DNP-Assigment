using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Age { get; set; }
    [JsonIgnore]
    public ICollection<Post>? Posts { get; set; }
}