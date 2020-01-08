using Blog.Service.Domain.Repositories;
using Blog.Service.Utils;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Blog.Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);          
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "blog-api",
                    Version = "v1",
                    Description = "An API for my personal blog",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Tendai Mzondo",
                        Email = "tmzonn@gmail.com",
                        // Url = new Uri("https://twitter.com/jwalkner"),
                    }
                });
            });
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSingleton(typeof(IRepository<>), typeof(BlogSqlRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
            });
        }
    }
}
