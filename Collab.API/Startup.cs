using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

using Swashbuckle.AspNetCore.Swagger;
using Collab.API.DAL;
using Collab.API.BLL;
using Collab.API.Models;
using Collab.API.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Collab.API.Auth;
using Microsoft.AspNetCore.Authorization;

namespace Collab.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string SwaggerVersion = "v1";

        private const string CorsPolicy = "AllowAllOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    }
                );
            });
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(CorsPolicy));
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies
                // is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => 
            {
                options.Authority = domain;
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });

            // TODO: Figure out how to implement role- or policy-based authorization properly
            services.AddAuthorization(options =>
            {
                options.AddPolicy("read:projects", policy => policy.Requirements.Add(new HasScopeRequirement("read:projects", domain)));
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register Swagger generator
            services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc(SwaggerVersion, new Info { Title = "Youtaite Collab API", Version = SwaggerVersion });
            });

            services.AddDbContext<CollabContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CollabDb")));

            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Group>, GroupRepository>();
            services.AddTransient<IRepository<Project>, ProjectRepository>();
            services.AddTransient<IRepository<Role>, RoleRepository>();
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            
            app.UseCors(CorsPolicy);
            app.UseAuthentication();
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
