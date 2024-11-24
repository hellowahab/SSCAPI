using Microsoft.EntityFrameworkCore;
using SSCAPI.Models;

namespace SSCAPI.Data
{
    public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Post> Posts { get; set; }
	}
}
