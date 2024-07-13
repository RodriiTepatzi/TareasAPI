using Microsoft.AspNetCore.Mvc;
using TareasEntrevista.Data.Schema;
using TareasEntrevista.Data.Services;
using TareasEntrevista.Models;

namespace TareasEntrevista.Controllers
{
	[Route("tasks")]
	public class TasksController : Controller
	{
		private readonly ITasksService _tasksService; 
        public TasksController(ITasksService tasksService)
        {
			_tasksService = tasksService;
        }

		[Route("create")]
		[HttpPost]
		public async Task<IActionResult> CreateTask([FromBody] TaskSchema tasks)
		{
			var task = await _tasksService.CreateTask(tasks.Name, tasks.Description);

			return Ok(task);
		}


		[Route("all")]
        [HttpGet]
		public async Task<IActionResult> GetAllTasks()
		{
			var tasks = await _tasksService.GetAllTasks();

			return Ok(tasks);
		}


		[Route("id/{id}")]
		[HttpGet]
		public async Task<IActionResult> GetTaskById(string id)
		{
			var task = await _tasksService.GetTaskById(id);

			return Ok(task);
		}

		[Route("update")]
		[HttpPut]
		public async Task<IActionResult> UpdateTask([FromBody] TaskApp task)
		{
			var taskUpadted = await _tasksService.UpdateTask(task);

			return Ok(taskUpadted);
		}
	}
}
