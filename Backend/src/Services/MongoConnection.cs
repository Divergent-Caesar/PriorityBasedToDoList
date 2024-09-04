using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

class MongoConnection
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

    public async Task fetchTasksAsync()
    {
        var tasks = await _tasksCollection.Find(new BsonDocument()).ToListAsync();

        foreach (var task in tasks)
        {
            Console.WriteLine(task["Subject"] + "\n" + task["TaskDescription"] + "\n" + task["EstimateInHours"]);
        }
    }

    public async Task deleteTask(String taskDescription)
    {
        await _tasksCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("TaskDescription", taskDescription));
        Console.WriteLine("Task Deleted Successfully");
    }

}