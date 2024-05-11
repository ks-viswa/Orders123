using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Db context to sqllite
builder.Services.AddDbContext<DataContext>(options =>
{
     options.UseSqlite(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

var app = builder.Build();

// Logging configuration
var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFilePath"].ToString());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
