namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GeneratedEnemySpellsConfiguration : IEntityTypeConfiguration<GeneratedEnemySpells>
    {
        public void Configure(EntityTypeBuilder<GeneratedEnemySpells> builder)
        {
            builder.HasKey(k => new { k.GeneratedEnemyId, k.SpellId });

            builder.HasOne(e => e.GeneratedEnemy)
                .WithMany(e => e.GeneratedEnemySpells)
                .HasForeignKey(e => e.GeneratedEnemyId);

            builder.HasOne(e => e.Spell)
                .WithMany(e => e.GeneratedEnemySpells)
                .HasForeignKey(e => e.SpellId);
        }
    }
}
