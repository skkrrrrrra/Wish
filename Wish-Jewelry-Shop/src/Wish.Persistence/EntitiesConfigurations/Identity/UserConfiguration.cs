using TeacherToys.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TeacherToys.Persistence.EntitiesConfigurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("identity_users").HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.UserName).HasColumnName("user_name");
        builder.Property(p => p.NormalizedUserName).HasColumnName("normalized_user_name");
        builder.Property(p => p.Email).HasColumnName("email");
        builder.Property(p => p.NormalizedEmail).HasColumnName("normalized_email");
        builder.Property(p => p.EmailConfirmed).HasColumnName("email_confirmed");
        builder.Property(p => p.PasswordHash).HasColumnName("password_hash");
        builder.Property(p => p.SecurityStamp).HasColumnName("security_stamp");
        builder.Property(p => p.ConcurrencyStamp).HasColumnName("concurrency_stamp");
        builder.Property(p => p.PhoneNumber).HasColumnName("phone_number");
        builder.Property(p => p.PhoneNumberConfirmed).HasColumnName("phone_number_confirmed");
        builder.Property(p => p.TwoFactorEnabled).HasColumnName("two_factor_enabled");
        builder.Property(p => p.LockoutEnd).HasColumnName("lockout_end");
        builder.Property(p => p.LockoutEnabled).HasColumnName("lockout_enabled");
        builder.Property(p => p.AccessFailedCount).HasColumnName("access_failed_count");
    }
}
