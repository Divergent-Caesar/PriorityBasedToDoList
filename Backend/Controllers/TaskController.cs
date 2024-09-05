using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Services;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskManager _taskManager;

        // Inject TaskManager service through the constructor
        public TaskController(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        // POST: /Task/Create
        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest request)
        {
            if (string.IsNullOrEmpty(request.Description) || request.TimeEstimate <= 0)
            {
                return BadRequest("Invalid task data.");
            }

            await _taskManager.CreateTask(request.Description, request.TimeEstimate, request.Category);
            return Ok("Task created successfully.");
        }

        // GET: /Task/GetAll
        [HttpGet("getAll")]
        public async Task<IActionResult> GetTasksAsync()
        {
            var tasksJson = await _taskManager.GetTasksAsync();
            return Ok(tasksJson);
        }
    }

    // DTO for CreateTask request
    public class CreateTaskRequest
    {
        public string Description { get; set; }
        public int TimeEstimate { get; set; }
        public string Category { get; set; } = "General";
    }
}
