using HackerNewsWrapperApi.Services;
using Polly;
using Serilog;

namespace HackerNewsWrapperApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomHttpClient(this IServiceCollection services)
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);
        services.AddHttpClient<HackerHttpService>()
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(serviceProvider.GetRequiredService<IConfiguration>()
                    .GetSection("HackerApi:Url").Value!);
            }).AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)))
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(6, TimeSpan.FromSeconds(5)))
            .AddPolicyHandler(request =>
            {
                if (request.Method == HttpMethod.Get) return timeoutPolicy;
                return Policy.NoOpAsync<HttpResponseMessage>();
            });
        return services;
    }

    public static IServiceCollection ConfigureSerilogLogging(this IServiceCollection services,
        IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        services.AddLogging(builder => builder.AddSerilog());
        return services;
    }
}