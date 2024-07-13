
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TareasEntrevista.Data;
using TareasEntrevista.Data.Services;

namespace TareasEntrevista
{
	public class Program
	{
		public static IConfiguration? Configuration { get; private set; }

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			Configuration = builder.Configuration;

			builder.Services.AddDbContext<AppDbContext>(
				options => options.UseSqlServer(
					Configuration.GetConnectionString("DefaultConnection"),
					providerOptions => providerOptions.EnableRetryOnFailure()
				));

			builder.Services.AddTransient<ITasksService, TasksService>();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();




			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}