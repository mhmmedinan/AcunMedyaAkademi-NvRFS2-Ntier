using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);


            builder.HasMany(x => x.UserOperationClaims);

        }
    }
}
