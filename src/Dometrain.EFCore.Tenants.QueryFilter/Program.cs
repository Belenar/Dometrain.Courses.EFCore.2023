using System.Text.Json.Serialization;
using Dometrain.EFCore.Tenants.QueryFilter.Data;
using Dometrain.EFCore.Tenants.QueryFilter.Repositories;
using Dometrain.EFCore.Tenants.QueryFilter.Tenants;
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
builder.Services.AddDbContextFactory<MoviesContext>(opt =>
{
    opt.UseSqlServer("""
        Data Source=localhost;
        Initial Catalog=MoviesDB;
        User Id=sa;
        Password=MySaPassword123;
        TrustServerCertificate=True;
        """);
});

var app = builder.Build();

// DIRTY HACK, we WILL come back to fix this
var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<MoviesContext>();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

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