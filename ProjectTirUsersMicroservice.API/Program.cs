
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ProjectTirUsersMicroservice.API.Endpoints;
using ProjectTirUsersMicroservice.Database;

namespace ProjectTirUsersMicroservice.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o => 
            o.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            }));

            builder.Services.AddDbContext<MicroserviceDbContext>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.AddUsersEndpoints();

            app.Run();
        }
    }
}
