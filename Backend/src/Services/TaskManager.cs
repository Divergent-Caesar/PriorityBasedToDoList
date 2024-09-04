using System.ComponentModel.Design;
using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

public class TaskManager : TaskManagerInterface
{
    private readonly MongoConnection mc;
    public TaskManager()
    {
        mc = new MongoConnection();
    }

    public async Task CreateTask(String taskDescription, int estimateInHours, String subject = "General")
    {
        BsonDocument newEntry = new BsonDocument
        {
            {"Subject", subject},
            {"TaskDescription", taskDescription},
            {"EstimateInHours", estimateInHours}
        };

        await mc.insertTask(newEntry);
    }

    public async Task GetTasksAsync()
    {
        await mc.fetchTasksAsync();
    }

    public async Task RemoveTask(String taskDescription)
    {
        await mc.deleteTask(taskDescription);
    }
}