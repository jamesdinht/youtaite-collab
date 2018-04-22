using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Collab.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Swagger;

namespace Collab
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string SwaggerVersion = "v1";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Register Swagger generator
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc(SwaggerVersion, new Info { Title = "Youtaite Collab API", Version = SwaggerVersion });
            });
        }

        // For Development environment
        public void ConfigureDevelopmentServices(IServiceCollection services) {
            services.AddMvc();

            services.AddDbContext<CollabContext>(options => 
                options.UseSqlite(Configuration.GetConnectionString("Sqlite")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            // Enable middleware to serve generated Swagger and Swagger UI
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{SwaggerVersion}/swagger.json", $"Youtaite Collab API {SwaggerVersion}");
            });
        }
    }
}
