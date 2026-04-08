using HackerNews.Core.Interfaces;
using HackerNews.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configure HttpClient using appsettings.json
builder.Services.AddHttpClient<IStoryRepository, HackerNewsRepository>(client =>
{
    // Leemos la URL desde la sección HackerNews:BaseUrl
    var baseUrl = builder.Configuration["HackerNews:BaseUrl"];

    if (string.IsNullOrEmpty(baseUrl))
    {
        throw new InvalidOperationException("HackerNews BaseUrl is not configured in appsettings.json");
    }

    client.BaseAddress = new Uri(baseUrl);
});

// 3. Enable in-memory caching
builder.Services.AddMemoryCache();

var app = builder.Build();

// 4. Configure the HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();