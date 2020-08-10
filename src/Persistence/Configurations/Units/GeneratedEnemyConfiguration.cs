namespace Persistence.Configurations.Units
{
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GeneratedEnemyConfiguration : IEntityTypeConfiguration<GeneratedEnemy>
    {
        public void Configure(EntityTypeBuilder<GeneratedEnemy> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50);
        }
    }
}
