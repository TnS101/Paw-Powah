namespace Persistence.Configurations.ManyToMany
{
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConsumeablesConfiguration : IEntityTypeConfiguration<PlayerConsumeables>
    {
        public void Configure(EntityTypeBuilder<PlayerConsumeables> builder)
        {
            builder.HasKey(k => new { k.PlayerId, k.ConsumeableId });

            builder.HasOne(e => e.Player)
                .WithMany(e => e.PlayerConsumeables)
                .HasForeignKey(e => e.PlayerId);

            builder.HasOne(e => e.Consumeable)
                .WithMany(e => e.PlayerConsumeables)
                .HasForeignKey(e => e.ConsumeableId);
        }
    }
}
