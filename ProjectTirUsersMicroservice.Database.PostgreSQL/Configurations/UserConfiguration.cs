using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTirUsersMicroservice.Database.PostgreSQL.Entities;

namespace ProjectTirUsersMicroservice.Database.PostgreSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users")
                .HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn();

            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Patronymic)
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.BirthdayDate)
                .IsRequired();
        }
    }
}
