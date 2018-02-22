using LeadMgmt.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeadMgmt.Api.Infrastructure
{
    public class LeadEntityTypeConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Lead");

            builder.Property(x => x.ID)
                .ValueGeneratedOnAdd() 
                .IsRequired();

            builder.Property(x => x.FullName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .IsRequired(true).HasMaxLength(20);

            builder.Property(x => x.EmailAddress)
                .IsRequired(false).HasMaxLength(50);

            builder.Property(x => x.LeadType)
               .IsRequired(true);

            builder.Property(x => x.BestTimeToCall)
              .IsRequired(false).HasMaxLength(50);

        }
    }
}