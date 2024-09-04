using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly TaskManagerInterface _taskManager;

    public TasksController(TaskManagerInterface taskManager)
    {
        _taskManager = taskManager;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTask([FromQuery] string taskDescription, [FromQuery] int estimateInHours, [FromQuery] string subject = "General")
    {
        await _taskManager.CreateTask(taskDescription, estimateInHours, subject);
        return Ok();
    }

    [HttpGet("get")]
    public async Task<IActionResult> GetTasks()
    {
        await _taskManager.GetTasksAsync();
        return Ok();
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveTask([FromQuery] string taskDescription)
    {
        await _taskManager.RemoveTask(taskDescription);
        return Ok();
    }
}
