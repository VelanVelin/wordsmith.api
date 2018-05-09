using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WordSmith.WebApi.Domain.Command.Commands;
using WordSmith.WebApi.Domain.Command.Handlers;
using WordSmith.WebApi.Domain.Command.Interfaces;
using WordSmith.WebApi.Domain.Query.Handlers;
using WordSmith.WebApi.Domain.Query.Interfaces;
using WordSmith.WebApi.Domain.Query.Queries;
using WordSmith.WebApi.Infrastructure;
using WordSmith.WebApi.Models.ReadModel;
using WordSmith.WebApi.Models.WriteModel;

namespace WordSmith.WebApi
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddMvc();

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=WordSmith;Trusted_Connection=True;ConnectRetryCount=0";
            var connection = @"Server=.\SQLEXPRESS;Initial Catalog=WordSmith;Integrated Security=True;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<SentenceContext>(options => options.UseSqlServer(connection));

            services.AddTransient<ICommandHandler<SaveSentenceCommand, CommandResponse>, SaveSentenceCommandHandler>();

            //services.AddTransient<SentenceQueryHandlerFactory>();
            services.AddTransient<IQueryHandler<AllSentencesQuery, IEnumerable<Sentence>>, AllSentencesQueryHandler>();
            services.AddTransient<IQueryHandler<SessionSentenceQuery, IEnumerable<Sentence>>, SessionSentenceQueryHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
