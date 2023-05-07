using TeacherToys.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wish.Domain.Entities.Identity;

namespace TeacherToys.Persistence.EntitiesConfigurations.Identity;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("identity_user_roles").HasKey(p => new { p.RoleId, p.UserId });
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.RoleId).HasColumnName("role_id");
    }
}
