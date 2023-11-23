using Serilog;
using Serilog.Filters;

namespace HackerNewsWrapperApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureSerilogLogging(this IServiceCollection services,
        IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration)
            .Filter.ByExcluding(Matching
            .FromSource("NamespaceContainingSensitiveCode")).CreateLogger();
        services.AddLogging(builder => builder.AddSerilog());
        return services;
    }
}