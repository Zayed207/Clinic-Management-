using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;

namespace DataLayer.Configrations
{
    public class UserConfigrations : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.UserID);

            builder.Property(u => u.UserName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Password).IsRequired();

            builder.Property(u => u.Email)
                   .HasMaxLength(200)
                   .IsRequired();
        }
    }
    }

