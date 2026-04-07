using HackerNews.Core.Interfaces;
using HackerNews.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configurar HttpClient para Hacker News
builder.Services.AddHttpClient<IStoryRepository, HackerNewsRepository>(client =>
{
    client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
});

// 3. Habilitar la caché en memoria (Vital para el rendimiento)
builder.Services.AddMemoryCache();

var app = builder.Build();

// 4. Configurar el pipeline de HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();