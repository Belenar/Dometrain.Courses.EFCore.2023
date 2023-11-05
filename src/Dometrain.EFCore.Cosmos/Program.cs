using System.Text.Json.Serialization;
using Dometrain.EFCore.Cosmos.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Configure Serilog
var serilog = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Configure it for Microsoft.Extensions.Logging
builder.Services.AddSerilog(serilog);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DbContext
builder.Services.AddDbContext<MoviesContext>(optionsBuilder =>
    {
        var connectionString = builder.Configuration.GetConnectionString("MoviesContext");
        optionsBuilder
            .UseCosmos(connectionString!,
                databaseName: "MoviesDB")
            .LogTo(Console.WriteLine);
    },
    ServiceLifetime.Scoped,
    ServiceLifetime.Singleton);

var app = builder.Build();

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