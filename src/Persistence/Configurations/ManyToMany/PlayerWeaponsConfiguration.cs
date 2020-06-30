namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerWeaponsConfiguration : IEntityTypeConfiguration<PlayerWeapons>
    {
        public void Configure(EntityTypeBuilder<PlayerWeapons> builder)
        {
            builder.HasKey(k => new { k.PlayerId, k.WeaponId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerWeapons)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Weapon)
                .WithMany(e => e.PlayerWeapons)
                .HasForeignKey(e => e.WeaponId);
        }
    }
}
