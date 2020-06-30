namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerSpellsConfiguration : IEntityTypeConfiguration<PlayerSpells>
    {
        public void Configure(EntityTypeBuilder<PlayerSpells> builder)
        {
            builder.HasKey(k => new { k.PlayerId, k.SpellId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerSpells)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Spell)
                .WithMany(e => e.PlayerSpells)
                .HasForeignKey(e => e.SpellId);
        }
    }
}
