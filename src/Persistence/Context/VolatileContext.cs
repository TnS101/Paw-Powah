namespace Persistence.Context
{
    using Application.Common.Interfaces;
    using Domain.Entities.Common;
    using Microsoft.EntityFrameworkCore;

    public class VolatileContext : DbContext, IVolatileContext
    {
        public VolatileContext(DbContextOptions<VolatileContext> options)
            : base(options)
        {
        }

        public DbSet<Cooldown> Cooldowns { get; set;}

        public DbSet<Duration> Durations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(new ConnectionString().VolatilePath);
            }
        }
    }
}
