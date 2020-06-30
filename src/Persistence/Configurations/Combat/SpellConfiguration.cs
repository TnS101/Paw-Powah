namespace Persistence.Configurations.Combat
{
    using Domain.Entities.Game.Combat;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SpellConfiguration : IEntityTypeConfiguration<Spell>
    {
        public void Configure(EntityTypeBuilder<Spell> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Kind)
                .WithOne(e => e.Spell)
                .HasForeignKey<Kind>(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
