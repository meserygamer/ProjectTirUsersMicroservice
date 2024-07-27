using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using ProjectTirUsersMicroservice.API.Endpoints;
using ProjectTirUsersMicroservice.Core.RepositoryInterfaces;
using ProjectTirUsersMicroservice.Database.PostgreSQL;
using ProjectTirUsersMicroservice.Database.PostgreSQL.Repositories;

namespace ProjectTirUsersMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o => 
                o.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                })
            );

            builder.Services.AddDbContext<MicroserviceDbContext>();

            var app = builder.Build();

            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Internal server error");
                });
            });

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.AddUsersEndpoints();

            app.Run();
        }
    }
}
