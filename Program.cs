using Microsoft.EntityFrameworkCore;
using SSCAPI.Data;

namespace SSCAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAngularClient", policy =>
				{
					policy.WithOrigins("http://localhost:4200")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			app.UseCors("AllowAngularClient");

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();
					

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
