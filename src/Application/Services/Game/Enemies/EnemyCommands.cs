namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Combat;
    using Application.Game.Stats;
    using Application.Services.Interfaces.Game.Enemies;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnemyCommands : BaseService, IEnemyCommands
    {
        public EnemyCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Attack(long id, long playerId)
        {
            var enemy = await this.Context.GeneratedEnemies.FindAsync(id);
            var player = await this.Context.Players.FindAsync(id);

            new Attack(enemy, player);

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Create(string name, double maxHP, double maxMana, double attackPower, double magicPower, double healthRegen, double manaRegen,
            double critChance, double attackSpeed, double movementSpeed, double tenacity, double armor, double resistance, string imagePath)
        {
            this.Context.Enemies.Add(new Enemy
            {
                Name = name,
                MaxHP = maxHP,
                MaxMana = maxMana,
                AttackPower = attackPower,
                MagicPower = magicPower,
                HealthRegen = healthRegen,
                ManaRegen = manaRegen,
                CritChance = critChance,
                AttackSpeed = attackSpeed,
                MovementSpeed = movementSpeed,
                Tenacity = tenacity,
                Armor = armor,
                Resistance = resistance,
                ImagePath = imagePath,
            });

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Delete(long id)
        {
            this.Context.Enemies.Remove(await this.Context.Enemies.FindAsync(id));

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Die(long id, long playerId)
        {
            var killedEnemy = await this.Context.GeneratedEnemies.FindAsync(id);

            var rewardedPlayer = await this.Context.Players.FindAsync(playerId);

            rewardedPlayer.Gold += killedEnemy.Gold;
            rewardedPlayer.XP += killedEnemy.XPReward;

            this.Context.GeneratedEnemies.Remove(killedEnemy);

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Generate(IPawContext context, int refLevel)
        {
            var baseEnemies = await context.Enemies.AsNoTracking().ToArrayAsync();

            var baseEnemy = baseEnemies[new Random().Next(baseEnemies.Length)];

            var generatedEnemyId = context.GeneratedEnemies.Add(new StatSet().EnemyStatSet(baseEnemy, refLevel)).Entity.Id;

            var dbSpells = context.Spells.Where(s => s.EnemyId == baseEnemy.Id).AsNoTracking();

            foreach (var spell in dbSpells)
            {
                context.GeneratedEnemiesSpells.Add(new GeneratedEnemySpells
                {
                    GeneratedEnemyId = generatedEnemyId,
                    SpellId = spell.Id,
                });
            }

            await context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task SpellCast(long id, long playerId)
        {
            var enemy = await this.Context.GeneratedEnemies.FindAsync(id);
            var player = await this.Context.Players.FindAsync(id);
        }

        public async Task Update(long id, string name, double maxHP, double maxMana, double attackPower, double magicPower, double healthRegen,
            double manaRegen, double critChance, double attackSpeed, double movementSpeed, double tenacity, double armor, double resistance, string imagePath)
        {
            var enemy = await this.Context.Enemies.FindAsync(id);

            if (!string.IsNullOrWhiteSpace(name))
            {
                enemy.Name = name;
            }

            if (maxHP > 0)
            {
                enemy.MaxHP = maxHP;
            }

            if (maxMana > 0)
            {
                enemy.MaxMana = maxMana;
            }

            if (healthRegen > 0)
            {
                enemy.HealthRegen = healthRegen;
            }

            if (manaRegen > 0)
            {
                enemy.ManaRegen = manaRegen;
            }

            if (attackPower > 0)
            {
                enemy.AttackPower = attackPower;
            }

            if (magicPower > 0)
            {
                enemy.MagicPower = magicPower;
            }

            if (armor > 0)
            {
                enemy.Armor = armor;
            }

            if (resistance > 0)
            {
                enemy.Resistance = resistance;
            }

            if (critChance > 0)
            {
                enemy.CritChance = critChance;
            }

            this.Context.Enemies.Update(enemy);

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
