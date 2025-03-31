using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

namespace Sample.Yarp.WebApi.Extensions;

public static class TelemetryExtension
{
    public static void AddOpenTelemetry(IServiceCollection services)
    {
		// Telemetria com OpenTelemetry
		services.AddOpenTelemetry()
		    .WithTracing(tracing =>
		    {
			    tracing
				    .AddAspNetCoreInstrumentation()
				    .AddHttpClientInstrumentation()
				    .AddOtlpExporter(); // Exporta para Jaeger, Zipkin ou outros
		    })
		    .WithMetrics(metrics =>
		    {
			    metrics
				    .AddAspNetCoreInstrumentation()
				    .AddHttpClientInstrumentation()
				    .AddRuntimeInstrumentation()
				    .AddProcessInstrumentation();
		    });
	}
}
