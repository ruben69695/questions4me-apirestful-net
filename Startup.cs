using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using questions4me_apirestful_net.Data;
using questions4me_apirestful_net.Data.Repositories;

namespace questions4me_apirestful_net
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddContextForInjection(Configuration);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddServicesForInjection(this IServiceCollection services) {
            return services
                .AddTransient<IQuestionRepository, QuestionRepository>();
        }

        public static IServiceCollection AddContextForInjection(this IServiceCollection services, IConfiguration configuration) {
            
            const string secretHostKey = "PostgresHost";
            const string secretUsernameKey = "PostgresUserName";
            const string secretPasswordKey = "PostgresPassword";

            var secretHostValue = configuration[secretHostKey];
            var secretUsernameValue = configuration[secretUsernameKey];
            var secretPasswordValue = configuration[secretPasswordKey];
            var connectionString = string.Empty;

            if (secretHostValue == null) {
                throw new ArgumentNullException(nameof(secretHostValue), $"Error: No secret named {secretHostKey} was found...");
            }
            else if (secretUsernameValue == null) {
                throw new ArgumentNullException(nameof(secretUsernameValue), $"Error: No secret named {secretUsernameKey} was found...");
            }
            else if (secretPasswordValue == null) {
                throw new ArgumentNullException(nameof(secretPasswordValue), $"Error: No secret named {secretPasswordKey} was found...");
            }

            connectionString 
                = $"Host={secretHostValue};Database=postgres;Username={secretUsernameValue};Password={secretPasswordValue}";

            return services
                .AddDbContext<Context>(options => options.UseNpgsql(connectionString));
        }
    }
}
