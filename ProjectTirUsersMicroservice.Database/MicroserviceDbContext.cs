using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTirUsersMicroservice.Database.Entities;

namespace ProjectTirUsersMicroservice.Database
{
    public class MicroserviceDbContext : DbContext
    {
        public MicroserviceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.MigrateAsync();
        }


        private readonly IConfiguration _configuration;


        public DbSet<UserEntity> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MicroserviceDbContext).Assembly);
        }
    }
}
