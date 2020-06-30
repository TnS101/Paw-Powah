namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerArmorsConfiguration : IEntityTypeConfiguration<PlayerArmors>
    {
        public void Configure(EntityTypeBuilder<PlayerArmors> builder)
        {
            builder.HasKey(k => new { k.PlayerId, k.ArmorId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerArmors)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Armor)
                .WithMany(e => e.PlayerArmors)
                .HasForeignKey(e => e.ArmorId);
        }
    }
}
