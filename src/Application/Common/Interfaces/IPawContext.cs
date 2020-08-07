namespace Application.Common.Interfaces
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using Domain.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IPawContext
    {
        DbSet<AppUser> Users { get; set; }

        DbSet<Player> Players { get; set; }

        DbSet<Enemy> Enemies { get; set; }

        DbSet<Amulet> Amulets { get; set; }

        DbSet<Armor> Armors { get; set; }

        DbSet<Consumeable> Consumeables { get; set; }

        DbSet<Weapon> Weapons { get; set; }

        DbSet<PlayerAmulets> PlayersAmulets { get; set; }

        DbSet<PlayerArmors> PlayersArmors { get; set; }

        DbSet<PlayerConsumeables> PlayersConsumeables { get; set; }

        DbSet<PlayerWeapons> PlayersWeapons { get; set; }

        DbSet<PlayerSpells> PlayersSpells { get; set; }

        DbSet<BattleClass> BattleClasses { get; set; }

        DbSet<Kind> Kinds { get; set; }

        DbSet<Spell> Spells { get; set; }

        DbSet<GeneratedEnemySpells> GeneratedEnemiesSpells { get; set; }

        DbSet<GeneratedEnemy> GeneratedEnemies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
