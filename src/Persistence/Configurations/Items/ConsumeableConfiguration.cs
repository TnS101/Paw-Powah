namespace Persistence.Configurations.Items
{
    using Domain.Entities.Game.Items;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConsumeableConfiguration : IEntityTypeConfiguration<Consumeable>
    {
        public void Configure(EntityTypeBuilder<Consumeable> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
