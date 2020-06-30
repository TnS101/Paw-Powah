namespace Persistence.Configurations.Combat
{
    using Domain.Entities.Game.Combat;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class KindConfiguration : IEntityTypeConfiguration<Kind>
    {
        public void Configure(EntityTypeBuilder<Kind> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.IncreaseStatType)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Spell)
                .WithOne(e => e.Kind)
                .HasForeignKey<Spell>(e => e.Id);
        }
    }
}
