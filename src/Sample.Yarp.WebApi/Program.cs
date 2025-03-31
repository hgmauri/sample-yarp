using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRouting(options => options.LowercaseUrls = true);
    builder.Services.AddControllers();

    // Adiciona suporte ao Reverse Proxy
    builder.Services.AddReverseProxy()
	    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

    builder.Services.AddOpenTelemetry();

	builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.MapControllers();
    app.MapReverseProxy();

	app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}