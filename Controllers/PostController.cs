using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSCAPI.Data;

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

	}
}
