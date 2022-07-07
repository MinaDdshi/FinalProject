using NLog.Web;
using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.Web;

var builder = WebApplication.CreateBuilder(args);
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions { EnvironmentName = Environments.Production });

builder.Host.ConfigureAppConfiguration(config =>
	config.SetBasePath(Directory.GetCurrentDirectory()).AddEnvironmentVariables());

builder.Host.ConfigureLogging(x => x.ClearProviders().SetMinimumLevel(LogLevel.Trace));

builder.Host.UseNLog();

var logger = NLogBuilder.ConfigureNLog(
		builder.Environment.IsProduction()
			? "nlog.config"
			: $"nlog.{builder.Environment.EnvironmentName}.config")
	.GetLogger("Info");

try
{
	builder.Services
		.InjectApi()
		.InjectSwagger()
		.InjectUnitOfWork()
		.InjectSieve()
		.InjectAuthentication()
		.AddEndpointsApiExplorer()
		.InjectNLog(builder.Environment)
		.InjectContext(builder.Configuration, builder.Environment)
		.InjectBusinesses()
		.InjectFluentValidation()
		.InjectAutoMapper()
		.InjectContentCompression();

	var app = builder.Build();

	await using var scope = app.Services.CreateAsyncScope();

	await using var context = scope.ServiceProvider.GetRequiredService<QuestionAnswerBackendContext>();

	await context.Database.EnsureCreatedAsync();

	if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Testing"))
		app.UseDeveloperExceptionPage()
			.UseSwagger()
			.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
				"Swagger Demo API v1"));
	else
		app.UseExceptionHandler("/Error")
			.UseHsts();

	app.UseHttpsRedirection()
		.UseStaticFiles()
		.UseRouting()
		.UseAuthentication()
		.UseAuthorization()
		.UseEndpoints(endpoints =>
		{
			if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Testing"))
				endpoints.MapHealthChecks("HealthCheck");
			endpoints.MapControllers();
		});

	await app.RunAsync();
}
catch (Exception exception)
{
	logger.Error(exception, "Program Stopped Because of Exception !");
	throw;
}
finally
{
	NLog.LogManager.Shutdown();
}

public partial class Program { }