using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using To_Do_app_Backend.Database;
using To_Do_app_Backend.Extensions;
using To_Do_app_Backend.Middleware;

var builder = WebApplication.CreateBuilder(args);

var connection = new SqliteConnection("Data Source=:memory:");
connection.Open();

builder.Services.AddControllers();
builder.Services.AddCustomServices();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(connection);
});

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();