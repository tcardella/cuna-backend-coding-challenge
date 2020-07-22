using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebAPI
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
            // HACK: I know this should be stored someplace more secure like Azure key vault, but I'm just trying to get things moving here.
            var accountEndpoint = "https://cuna-bcc.documents.azure.com:443/";
            var accountKey = "c8y7PaepIdE1dxfMTfEqnNtzklKOQJxqPOxdqd4jOCYJbFBWkDkbYG4SFm3Fnqc7Djg7q2DHXKe0mhrA31n6tA==";
            var databaseName = "RequestDB";

            services.AddDbContext<RequestContext>(options => options.UseCosmos(accountEndpoint, accountKey, databaseName));

            services.AddControllers();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "CUNA Backend Coding Challenge API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "CUNA Backend Coding Challenge API V1"); });
        }
    }
}