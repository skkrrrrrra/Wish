using TeacherToys.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wish.Domain.Entities.Identity;

namespace TeacherToys.Persistence.EntitiesConfigurations.Identity;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable("identity_user_tokens").HasKey(p => new { p.LoginProvider, p.UserId, p.Name });
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.LoginProvider).HasColumnName("login_provider");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Value).HasColumnName("value");
    }
}
