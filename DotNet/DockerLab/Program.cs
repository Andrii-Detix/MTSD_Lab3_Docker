using DockerLab.Database;
using DockerLab.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string configuration = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseNpgsql(configuration);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ApplyMigrations();
app.MapGet("/", () => "Hello World!");
app.UseUserEndPoints();

app.Run();