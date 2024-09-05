using System.Threading.Tasks;

namespace Backend.Services
{
    public interface IMyService
    {
        Task<string> GetDataAsync();
    }

    public class MyService : IMyService
    {
        public async Task<string> GetDataAsync()
        {
            // Simulate an asynchronous operation
            await Task.Delay(1000);
            return "Hello from MyService";
        }
    }
}
