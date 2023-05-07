using TeacherToys.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wish.Domain.Entities.Identity;

namespace TeacherToys.Persistence.EntitiesConfigurations.Identity;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable("identity_user_logins").HasKey(p => new { p.LoginProvider, p.ProviderKey });
        builder.Property(p => p.LoginProvider).HasColumnName("login_provider");
        builder.Property(p => p.ProviderKey).HasColumnName("provider_key");
        builder.Property(p => p.ProviderDisplayName).HasColumnName("provider_display_name");
        builder.Property(p => p.UserId).HasColumnName("user_id");
    }
}
