using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddSingleton<MongoConnection>(); // Register as a singleton or scoped based on your needs
builder.Services.AddScoped<TaskManager>();

builder.Services.AddControllers(); // Add other services as needed
builder.Services.AddAuthorization(); // Register authorization services

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();