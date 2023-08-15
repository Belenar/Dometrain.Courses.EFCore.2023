using System.Text.Json.Serialization;
using Dometrain.EFCore.API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
var serilog = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Configure it for Microsoft.Extensions.Logging
builder.Services.AddSerilog(serilog);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add a DbContext here
builder.Services.AddDbContext<MoviesContext>(optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("MoviesContext");
        optionsBuilder
            .UseSqlServer(connectionString)
            .LogTo(Console.WriteLine);
    },
    ServiceLifetime.Scoped,
    ServiceLifetime.Singleton);

var app = builder.Build();

// Check if the DB was migrated
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MoviesContext>();
var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
if (pendingMigrations.Any())
    throw new Exception("Database is not fully migrated for MoviesContext.");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();