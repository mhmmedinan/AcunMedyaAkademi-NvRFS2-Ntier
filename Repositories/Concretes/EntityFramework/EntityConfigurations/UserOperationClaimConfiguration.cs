using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.UserId).HasColumnName("Name").IsRequired();
            builder.Property(x => x.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();


            builder.HasOne(x => x.User);
            builder.HasOne(x => x.OperationClaim);

        }
    }
}
