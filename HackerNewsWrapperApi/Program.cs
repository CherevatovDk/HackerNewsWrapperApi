using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Options;
using HackerNewsWrapperApi.Services;

var builder = WebApplication.CreateBuilder(args);
new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory(
    )).AddJsonFile("appsettings.json").Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetSection("HackerApi:Url").Value!);
    
});
builder.Services.AddScoped<IHackerHttpService, HackerHttpService>();
builder.Services.Configure<HackerApiSettings>(builder.Configuration.GetSection("HackerApi"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run(async (context) =>
{
    var response = context.Response;
    response.Headers.ContentLanguage = "ru-RU";
    response.Headers.ContentType = "text/plain; charset=utf-8";
    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
    await response.WriteAsync("Привет METANIT.COM");
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();