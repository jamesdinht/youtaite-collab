using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

using Swashbuckle.AspNetCore.Swagger;
using Collab.DAL;
using Collab.BLL;
using Collab.Models;
using Collab.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

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

        private const string localdevURL = "http://localhost:4200";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddCors();

            // Register Swagger generator
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc(SwaggerVersion, new Info { Title = "Youtaite Collab API", Version = SwaggerVersion });
            });

            services.AddDbContext<CollabContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CollabDb")));

            services.AddTransient<IRepository<User>, UserRepository>();
        }

        // For Development environment
        public void ConfigureDevelopmentServices(IServiceCollection services) {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins(localdevURL)
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }
                );
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigins"));
            });

            services.AddMvc();
            
            services.AddDbContext<CollabContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("CollabDb")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(SwaggerVersion, new Info { Title = "Youtaite Collab API Dev", Version = SwaggerVersion });
            });

            services.AddTransient<IRepository<User>, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors("AllowSpecificOrigins");
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
