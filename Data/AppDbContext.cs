using Microsoft.EntityFrameworkCore;
using TareasEntrevista.Models;

namespace TareasEntrevista.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<TaskApp> Tasks { get; set; }
	}
}
