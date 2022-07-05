using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog.Web;
using Sieve.Services;
using QuestionAnswerBackend.Api.Contracts;
using QuestionAnswerBackend.Api.Filters;
using QuestionAnswerBackend.Business.Contract;
using QuestionAnswerBackend.Common.Profiles;
using QuestionAnswerBackend.Common.Validations;
using QuestionAnswerBackend.DataAccess;
using QuestionAnswerBackend.DataAccess.Context;
using QuestionAnswerBackend.DataAccess.Contracts;
using System.IO.Compression;
using System.Resources;
using System.Text.Json.Serialization;

namespace QuestionAnswerBackend.Web;

internal static class DependencyInjectionExtension
{
    internal static IServiceCollection InjectApi(this IServiceCollection services) =>
            services
            .AddControllers(x => x.Filters.Add<CustomExceptionFilter>())
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            })
            .AddApplicationPart(typeof(IBaseController<>).Assembly)
            .Services
            .AddHealthChecks()
            .Services
            .AddSingleton(_ => new ResourceManager(typeof(Messages)));

    internal static IServiceCollection InjectSwagger(this IServiceCollection services) =>
        services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "SSPTraining.Api", Version = "v1" }));

    internal static IServiceCollection InjectUnitOfWork(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    internal static IServiceCollection InjectContext(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment environment) =>
        environment.IsDevelopment() || environment.IsEnvironment("Testing")
            ? services.AddDbContextPool<QuestionAnswerBackendContext>(options =>
                options.UseInMemoryDatabase("QuestionAnswer"))
            : services.AddDbContextPool<QuestionAnswerBackendContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("QuestionAnswerBackendContext")));

    internal static IServiceCollection InjectNLog(this IServiceCollection services,
        IWebHostEnvironment environment)
    {
        var factory = NLogBuilder.ConfigureNLog(
                environment.IsProduction()
                    ? "nlog.config"
                    : $"nlog.{environment.EnvironmentName}.config");
        return services.AddSingleton(_ => factory.GetLogger("Info"))
            .AddSingleton(_ => factory.GetLogger("Error"));
    }

    internal static IServiceCollection InjectSieve(this IServiceCollection services) =>
        services.AddScoped<ISieveProcessor, SieveProcessor>();

    internal static IServiceCollection InjectAuthentication(this IServiceCollection services) =>
        services
            .AddAuthorization()
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = options.DefaultChallengeScheme =
                    CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                options.AccessDeniedPath = "/Account/AccessDenied";
            })
            .Services;

    internal static IServiceCollection InjectBusinesses(this IServiceCollection services) =>
        services.Scan(scan =>
                scan.FromAssembliesOf(typeof(IBaseBusiness<>))
                    .AddClasses(classes =>
                        classes.AssignableTo(typeof(IBaseBusiness<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
                    .AddClasses(classes =>
                        classes.Where(predicate =>
                            predicate.Name.EndsWith("Business") && !predicate.IsAssignableTo(typeof(IBaseBusiness<>))))
                    .AsSelf()
                    .WithScopedLifetime());

    internal static IServiceCollection InjectContentCompression(this IServiceCollection services) =>
        services.Configure<GzipCompressionProviderOptions>
                (options => options.Level = CompressionLevel.Fastest)
            .AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());

    internal static IServiceCollection InjectFluentValidation(this IServiceCollection services) =>
        services.AddFluentValidation(fv =>
            fv.RegisterValidatorsFromAssemblyContaining<RoleValidator>());

    internal static IServiceCollection InjectAutoMapper(this IServiceCollection services) =>
        services.AddAutoMapper(typeof(UserProfile).Assembly);
}