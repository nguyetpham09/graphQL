using CarvedRock.Api.Data;
using CarvedRock.Api.GraphQL;
using CarvedRock.Api.Infrastructure.Repositories;
using CarvedRock.Api.Infrastructure.Services;

using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQl_solution.Database;
using GraphQl_solution.GraphQL;
using GraphQl_solution.Infrastructure;
using GraphQl_solution.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using MediatR.Pipeline;

namespace CarvedRock.Api
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(context =>
            {
                context.UseInMemoryDatabase("database");
            });
            //services.AddScoped<ProductRepository>();
            services.AddScoped<AuthorRepository>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddScoped<AuthorSchema>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            services.AddScoped<BookSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = false; })
                .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddMediatR(typeof(Startup));
            
        }
        public void Configure(IApplicationBuilder app, GraphQl_solution.Database.AppDbContext dbContext)
        {
            //app.UseGraphQL<CarvedRockSchema>();
            app.UseGraphQL<AuthorSchema>();
            app.UseGraphQL<BookSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            //dbContext.Seed();
        }
    }
}