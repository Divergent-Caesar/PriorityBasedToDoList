using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options => {
        options.AddPolicy("AllowAngularApp",
            policy => policy.WithOrigins("http://localhost:4200")
                            .AllowAnyHeader()
                            .AllowAnyMethod());
    });

    builder.Services.AddScoped<TaskManagerInterface, TaskManager>();

    builder.Services.AddAuthorization();
    
}
var app = builder.Build();
{
    app.UseCors("AllowAngularApp");
    // Map basic endpoints
    app.UseAuthorization();
    app.MapPost("/api/tasks/create", async (TaskManagerInterface taskManager, string taskDescription, int estimateInHours, string subject) =>
    {
        await taskManager.CreateTask(taskDescription, estimateInHours, subject);
        return Results.Ok();
    });

    app.MapGet("/api/tasks/get", async (TaskManagerInterface taskManager) =>
    {
        await taskManager.GetTasksAsync();
        return Results.Ok();
    });

    app.MapDelete("/api/tasks/remove", async (TaskManagerInterface taskManager, string taskDescription) =>
    {
        await taskManager.RemoveTask(taskDescription);
        return Results.Ok();
    });

        app.MapGet("/", () => "Hello, World!"); // Basic route for testing
    }


app.Run();
