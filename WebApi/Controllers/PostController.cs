using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;
using WebApi.Services;

namespace WebApi.Controllers;



[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService postService;

    public PostController(IPostService postService)
    {
        this.postService = postService;
    }

    [HttpPost, Route("create")]
    public async Task<ActionResult> Create([FromBody] PostCreationDto dto)
    {
        try
        {
            postService.CreatePost(dto);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet, Route("get")]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync()
    {
        try
        {

            IEnumerable<Post> posts = await postService.GetPosts();
            return Ok(posts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet, Route("get/{id:int}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] int id)
    {
        try
        {

            Post post = await postService.GetPostById(id);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}