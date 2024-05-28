using DataAccess;
using Domain.Interfaces;
using JobAssignmentSplititExam.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Repositories.Interfaces;
using Repositories.Repos;
using Services;
using Services.Scrapers;
using Services.Settings;
using System.Reflection;

namespace JobAssignmentSplititExam
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add Swagger services
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Assignment Splitit Exam", Version = "v1" });
            });
            builder.Services.Configure<ScraperSettings>(builder.Configuration.GetSection("ScraperSettings"));
            builder.Services.AddDbContext<DBContext>(options =>
                 options.UseInMemoryDatabase("ActorsDB"));
            builder.Services.AddScoped<IActorService, ActorService>();
            builder.Services.AddScoped<IActorRepository, ActorRepository>();
            builder.Services.AddScoped<IScraper, IMDbScraper>();
            builder.Services.AddScoped<IScraperService, ScraperService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Job Assignment Splitit Exam V1"));
            }
            app.UseRouting();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Scraping
            using (var scope = app.Services.CreateScope())
            {
                var scraperService = scope.ServiceProvider.GetRequiredService<IScraperService>();
                var dbContext = scope.ServiceProvider.GetRequiredService<DBContext>();
                dbContext.Database.EnsureCreated();
                await scraperService.ScrapeActorsAsync();
            }

            app.Run();
        }
    }
}