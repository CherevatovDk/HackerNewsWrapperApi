using Polly;

namespace HackerNewsWrapperApi.Extensions;

public static class HttpClientExtensions
{
    public static IServiceCollection AddMyHttpClient<TClient>(this IServiceCollection services,
        string configurationSectionName) where TClient : class
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);
        services.AddHttpClient<TClient>()
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                client.BaseAddress = new Uri(serviceProvider.GetRequiredService<IConfiguration>()
                    .GetSection(configurationSectionName).Value!);
            }).AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)))
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(6, TimeSpan.FromSeconds(5)))
            .AddPolicyHandler(request =>
            {
                if (request.Method == HttpMethod.Get) return timeoutPolicy;
                return Policy.NoOpAsync<HttpResponseMessage>();
            });
        return services;
    }
}