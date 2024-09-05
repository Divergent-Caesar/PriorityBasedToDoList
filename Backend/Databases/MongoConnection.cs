using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Text.Json;
using System.Threading.Tasks;

public class MongoConnection
{
    private const string ConnectionString = "mongodb://localhost:27017"; // Replace with your MongoDB URI

    // Database and collection names
    private const string DatabaseName = "PriorityList";
    private const string CollectionName = "Tasks";

    // MongoClient instance
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<BsonDocument> _tasksCollection;

    public MongoConnection()
    {
        _client = new MongoClient(ConnectionString);
        _database = _client.GetDatabase(DatabaseName);
        _tasksCollection = _database.GetCollection<BsonDocument>(CollectionName);
    }

    public async Task insertTask(BsonDocument task)
    {
        await _tasksCollection.InsertOneAsync(task);
        Console.WriteLine("Task Inserted Successfully");
    }

    public async Task<string> fetchTasksAsync()
    {
        var tasks = await _tasksCollection.Find(new BsonDocument()).ToListAsync();
        var result = new List<Tasks>();
        foreach (var task in tasks)
        {
            var temp = new Tasks
            {
                _subject = task["Subject"].AsString,
                _taskDescription = task["TaskDescription"].AsString,
                _timeEstimate = task["EstimateInHours"].AsInt32
            };
            result.Add(temp);
        }

        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(result, jsonOptions);

        return jsonString;
    }

    public async Task deleteTask(String taskDescription)
    {
        await _tasksCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("TaskDescription", taskDescription));
        Console.WriteLine("Task Deleted Successfully");
    }

}

internal class Tasks
{
    public string _taskDescription { get; set; }
    public string _subject { get; set; }
    public int _timeEstimate { get; set; }
}