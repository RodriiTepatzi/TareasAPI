using TareasEntrevista.Models;

namespace TareasEntrevista.Data.Services
{
	public interface ITasksService
	{
		Task<TaskApp> CreateTask(string name, string description);
		Task<List<TaskApp>> GetAllTasks();
		Task<TaskApp?> GetTaskById(string id);
		Task<TaskApp> UpdateTask(TaskApp task);

	}
}
