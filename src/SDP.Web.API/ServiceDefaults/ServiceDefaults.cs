using Microsoft.AspNetCore.Builder;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SDP.Web.API.Infrastructure.Data;
using Serilog;
using System.Text.Json.Serialization;

namespace SDP.Web.API.ServiceDefaults
{
    public static class ServiceDefaults
    {

        public static TBuilder ConfigureApi<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            return builder;
        }

        public static void UseMiddlewares(this WebApplication app)
        {
            app.MapHealthChecks("/api/Health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            });
        }

        public static TBuilder AddMiddlewares<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.AddDatabasePersistence();
            builder.ConfigureHealthChecks();

            return builder;
        }

        private static TBuilder AddDatabasePersistence<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddDbContext<WebAppDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DbConnection"),
                    provideroptions => provideroptions.EnableRetryOnFailure()
                )
            );

            return builder;
        }

        private static TBuilder ConfigureHealthChecks<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddHealthChecks().AddSqlServer(
                builder.Configuration.GetConnectionString("DbConnection") ?? string.Empty
            );

            return builder;
        }

        public static void ConfigureLogging(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, configuration) =>
            {
                configuration.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
