using TeacherToys.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wish.Domain.Entities.Identity;

namespace TeacherToys.Persistence.EntitiesConfigurations.Identity;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("identity_roles").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.ConcurrencyStamp).HasColumnName("concurrency_stamp");
        builder.Property(p => p.NormalizedName).HasColumnName("normalized_name");
    }
}
