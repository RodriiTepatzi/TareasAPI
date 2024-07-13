using Microsoft.EntityFrameworkCore;
using TareasEntrevista.Models;

namespace TareasEntrevista.Data.Services
{
	public class TasksService : ITasksService
	{
		private readonly AppDbContext _context;
        public TasksService(AppDbContext context)
        {
			_context = context;
        }

		public async Task<TaskApp> CreateTask(string name, string description)
		{
			var tasksToBeInserted = new TaskApp{
				Name = name,
				Description = description,
				IsCompleted = false
			};

			var result = await _context.Tasks.AddAsync(tasksToBeInserted);

			await _context.SaveChangesAsync();

			return result.Entity;
		}

		public async Task<List<TaskApp>> GetAllTasks()
		{
			var tasks = await _context.Tasks.ToListAsync();

			return tasks;
		}

		public async Task<TaskApp?> GetTaskById(string id)
		{
			var task = await _context.Tasks.Where(t => t.Id == id).ToListAsync();

			if (task.Count > 0)
			{
				return task.First();
			}

			return null;

		}

		public async Task<TaskApp> UpdateTask(TaskApp taskApp)
		{
			var taskTemp = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskApp.Id);

			if (taskTemp != null)
			{
				var task = _context.Entry(taskTemp);

				task.Entity.Name = taskApp.Name;
				task.Entity.Description = taskApp.Description;
				task.Entity.IsCompleted = taskApp.IsCompleted;

				task.State = EntityState.Modified;

				await _context.SaveChangesAsync();
			}

			return taskApp;
		}	
	}
}
