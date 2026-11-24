using GymMangementG01.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangementG01.Configration
{
    public class MemberConfigration:GymUserConfigration<Member>,IEntityTypeConfiguration<Member>
    {
        public new void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()")
                .HasColumnName("JoinDate");

            base.Configure(builder);
        }
    }
}
