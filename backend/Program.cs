using Backend.Models;
using Backend.Services;
using Backend.Services.Interfaces;
using MongoDB.Bson.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Ignore fields like __v that don't exist in the model
BsonClassMap.RegisterClassMap<Project>(cm =>
{
    cm.AutoMap();
    cm.SetIgnoreExtraElements(true); 
});
BsonClassMap.RegisterClassMap<Email>(cm =>
{
    cm.AutoMap();
    cm.SetIgnoreExtraElements(true);
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services, this connects interfaces with services and creates a new instance per request
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IEmailService, EmailService>();
// Allows [ApiController] classes to receive HTTP requests
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();
