using GymMangementG01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementG01.Configration
{
    public class MemberShipConfigration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.Plan)
                .WithMany(x => x.PlanSubscriptions)
                .HasForeignKey(x => x.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Member)
                .WithMany(x => x.MemberSubscriptions)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
