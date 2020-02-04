using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Front_End_Assesment.GraphQL.GraphQLTypes;
using Front_End_Assesment.GraphQL.InputTypes;
using Front_End_Assesment.GraphQL.Schemas;
using Front_End_Assesment.Interfaces;
using Front_End_Assesment.MessageHandlers;
using Front_End_Assesment.Models;
using Front_End_Assesment.Repositories;
using GraphiQl;
using GraphQL;
using GraphQL.Http;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using static Front_End_Assesment.GraphQL.Schemas.ProjectShema;

namespace Front_End_Assesment
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
            services.AddControllers();
            services.AddScoped<ProjectQuery>();
            services.AddScoped<ProjectMutation>();
            services.AddHttpContextAccessor();
            services.AddScoped<Iproject, ProjectRepository>();
            services.AddScoped<ISchema, Schema>();
            services.AddScoped<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<IDocumentWriter, DocumentWriter>();
            services.AddScoped<LoginType>();
            services.AddScoped<LoginResponseType>();
            services.AddScoped<GenericResponseType>();
            services.AddScoped<LocationType>();
            services.AddScoped<ProjectType>();
            services.AddScoped<LoginInputType>();
            services.AddScoped<ProjectInputType>();

            services.AddSingleton<JWTAuthHandler>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
           services.AddScoped<ProjectShema>();
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddEntityFrameworkSqlite().AddDbContext<ProjectContext>();
            using (var client = new ProjectContext())
            {
                client.Database.EnsureCreated();
            }
            services.AddGraphQL(o => { o.ExposeExceptions = false; })
               .AddGraphTypes(ServiceLifetime.Scoped);
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();


            }

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthorization();

            app.UseAuthentication();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ProjectShema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            // app.UseMvc();
        }
    }
}
