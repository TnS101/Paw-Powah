namespace Persistence.Context
{
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using Domain.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class PawContext : IdentityDbContext<AppUser, ApplicationRole, string>, IPawContext
    {
        public PawContext(DbContextOptions<PawContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Enemy> Enemies { get; set; }

        public DbSet<Amulet> Amulets { get; set; }

        public DbSet<Armor> Armors { get; set; }

        public DbSet<Consumeable> Consumeables { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<PlayerAmulets> PlayersAmulets { get; set; }

        public DbSet<PlayerArmors> PlayersArmors { get; set; }

        public DbSet<PlayerConsumeables> PlayersConsumeables { get; set; }

        public DbSet<PlayerWeapons> PlayersWeapons { get; set; }

        public DbSet<GeneratedEnemySpells> GeneratedEnemiesSpells { get; set; }

        public DbSet<BattleClass> Classes { get; set; }

        public DbSet<Kind> Kinds { get; set; }

        public DbSet<Spell> Spells { get; set; }

        public DbSet<PlayerSpells> PlayersSpells { get; set; }

        public DbSet<GeneratedEnemy> GeneratedEnemies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PawContext).Assembly);

            modelBuilder.Entity<AppUser>(appUser =>
            {
                appUser
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

                appUser
                    .HasMany(e => e.Logins)
                    .WithOne()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                appUser
                    .HasMany(e => e.Roles)
                    .WithOne()
                    .HasForeignKey(e => e.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

