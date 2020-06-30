namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Combat;
    using Application.Game.Stats;
    using Application.Services.Interfaces.Game.Enemies;
    using AutoMapper;
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnemyCommands : MapService, IEnemyCommands
    {
        public EnemyCommands(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task Attack(long id, long playerId)
        {
            var enemy = await this.Context.GeneratedEnemies.FindAsync(id);
            var player = await this.Context.Players.FindAsync(id);

            new Attack(enemy, player);

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
    }
}
