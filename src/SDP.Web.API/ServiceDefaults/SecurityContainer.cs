using System.Reflection;

namespace SDP.Web.API.ServiceDefaults
{
    public static class SecurityContainer
    {
        public static TBuilder ConfigureSecurity<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.ConfigureSecurityPolices();
            builder.Services.AddDataProtection();

            return builder;
        }

        public static TApp UseSecurityConfiguration<TApp>(this TApp app) where TApp : IApplicationBuilder
        {
            app.UseCors("CORS");

            return app;
        }

        private static TBuilder ConfigureSecurityPolices<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
        {
            builder.Services.AddCors(options => options.AddPolicy("CORS", policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));

            return builder;
        }
    }
}
