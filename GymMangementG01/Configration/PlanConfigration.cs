using GymMangementG01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementG01.Configration
{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("PlanDurationCheck", "DurationDays between 1 and 365");
            });
        }
    }
}
