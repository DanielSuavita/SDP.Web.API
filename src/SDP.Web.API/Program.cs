using Microsoft.EntityFrameworkCore;
using SDP.Web.API.Infrastructure.Data;
using SDP.Web.API.ServiceDefaults;

namespace SDP.Web.API
{
    internal class Program
    {
        protected Program() { }

        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.ConfigureApi();
            builder.AddMiddlewares();
            builder.ConfigureLogging();
            builder.ConfigureSecurity();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddlewares();

            app.UseSecurityConfiguration();

            app.Run();
        }
    }
}