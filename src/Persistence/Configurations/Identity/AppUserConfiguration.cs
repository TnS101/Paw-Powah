namespace Persistence.Configurations.Identity
{
    using Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.ToTable("Users");
        }
    }
}
