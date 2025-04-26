using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Concretes.EntityFramework.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("Id").IsRequired();
            builder.Property(x => x.ModelId).HasColumnName("ModelId").IsRequired();
            builder.Property(x => x.ModelYear).HasColumnName("ModelYear").IsRequired();
            builder.Property(x => x.State).HasColumnName("State").IsRequired();
            builder.Property(x => x.DailyPrice).HasColumnName("DailyPrice").IsRequired();
            builder.Property(x => x.Plate).HasColumnName("Plate").IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Model);


        }
    }
}
