using EMS.webapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EMS.webapp.ModelConfiguration
{
    public class EmployeConfiguration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
           builder.ToTable(nameof(Employe));
            builder.HasKey(x => x.id);
            builder.Property(x => x.name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(256).IsRequired();
        }
    }
}
