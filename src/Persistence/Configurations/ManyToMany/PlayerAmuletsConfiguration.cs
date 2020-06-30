namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerAmuletsConfiguration : IEntityTypeConfiguration<PlayerAmulets>
    {
        public void Configure(EntityTypeBuilder<PlayerAmulets> builder)
        {
            builder.HasKey(k => new { k.PlayerId, k.AmuletId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerAmulets)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Amulet)
                .WithMany(e => e.PlayerAmulets)
                .HasForeignKey(e => e.AmuletId);
        }
    }
}
