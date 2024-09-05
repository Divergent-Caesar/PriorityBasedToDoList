using System.Threading.Tasks;
using MongoDB.Bson;

namespace Backend.Services
{
    public interface IBackendService
    {
        Task CreateTask(string description, int timeEstimate, string category = "General");
        Task<string> GetTasksAsync();
    }
    public class TaskManager
    {
        private MongoConnection mc;

        public TaskManager(MongoConnection mc)
        {
            this.mc = mc;
        }
        public async Task CreateTask(string description, int timeEstimate, string category = "General")
        {
            BsonDocument newEntry = new BsonDocument
            {
                {"Subject", category},
                {"TaskDescription", description},
                {"EstimateInHours", timeEstimate}
            };
            await mc.insertTask(newEntry);
        }

        public async Task<string> GetTasksAsync()
        {
            return await mc.fetchTasksAsync();
        }
    }
}
