using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(50);
            builder.Property(x => x.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(x => x.PasswordSalt).HasColumnName("PasswordSalt");


            builder.HasMany(x => x.UserOperationClaims);

        }
    }
}
