namespace Shared.Dtos;

public class PostCreationDto
{
    public string Title{get;set;}
    public string Body{get;set;}
    public string AuthorUsername{get;set;}

    public PostCreationDto(string title, string body, string authorUsername)
    {
        Title = title;
        Body = body;
        AuthorUsername = authorUsername;
    }
}