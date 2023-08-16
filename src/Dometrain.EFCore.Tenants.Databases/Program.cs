using System.Text.Json.Serialization;
using Dometrain.EFCore.Tenants.Databases.Data;
using Dometrain.EFCore.Tenants.Databases.Repositories;
using Dometrain.EFCore.Tenants.Databases.Tenants;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.OperationFilter<TenantHeaderSwaggerAttribute>();
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<TenantService>();

// Add a DbContext here
builder.Services.AddDbContext<MoviesContext>((services, options) =>
{
    var tenantService = services.GetRequiredService<TenantService>();
    var configuration = services.GetRequiredService<IConfiguration>();
    var connectionString = configuration
        .GetConnectionString($"MoviesContext_{tenantService.GetTenantId()}");
    options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine);
});

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