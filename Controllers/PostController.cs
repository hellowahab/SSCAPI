using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSCAPI.Data;
using SSCAPI.Models;

namespace SSCAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PostController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public PostController(ApplicationDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPosts()
		{
			var posts = await _context.Posts.ToListAsync();
			return Ok(posts);
		}

		[HttpPost]
		public async Task<IActionResult> SavePost([FromBody] Post post)
		{ 
			if(post == null)
			{
				return BadRequest("Post is null");
			}
			post.CreatedAt = DateTime.UtcNow;
			await _context.Posts.AddAsync(post);
			await _context.SaveChangesAsync();
			return Ok(post);
		}

	}
}
