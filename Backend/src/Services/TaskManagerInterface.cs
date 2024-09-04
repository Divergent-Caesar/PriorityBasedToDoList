public interface TaskManagerInterface
{
    Task CreateTask(string taskDescription, int estimateInHours, string subject = "General");
    Task GetTasksAsync();
    Task RemoveTask(string taskDescription);
}

