namespace Persistence.Configurations.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AmuletConfiguration : IEntityTypeConfiguration<Amulet>
    {
        public void Configure(EntityTypeBuilder<Amulet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.BuffStatType)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.ImagePath)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
