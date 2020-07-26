namespace Persistence.Configurations.Combat
{
    using Domain.Entities.Game.Combat;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClassConfiguration : IEntityTypeConfiguration<BattleClass>
    {
        public void Configure(EntityTypeBuilder<BattleClass> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(400)
                .IsRequired();

        }
    }
}
