using GymMangementG01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementG01.Configration
{
    public class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("SessionCapacityConstrain", "Capacity between 1 and 25");
                T.HasCheckConstraint("SessionEndDateAfterStartDate", "EndDate > StartDate");
            });

            builder.HasOne(x => x.Trainer)
                .WithMany(x => x.Sessions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
