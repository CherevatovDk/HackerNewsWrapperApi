using HackerNewsWrapperApi.Extensions;
using HackerNewsWrapperApi.Filters;
using HackerNewsWrapperApi.Interfaces;
using HackerNewsWrapperApi.Options;
using HackerNewsWrapperApi.Services;

var builder = WebApplication.CreateBuilder(args);

new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.ConfigureSerilogLogging(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDetailsService, DetailsService>();
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.Configure<HackerApiSettings>(builder.Configuration.GetSection("HackerApi"));
builder.Services.AddMyHttpClient<HackerHttpService>("HackerApi:Url");


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/Error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
