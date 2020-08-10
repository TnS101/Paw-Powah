namespace Application.Services.Game.GeneratedEnemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Combat;
    using Application.Game.Stats;
    using Application.Services.Interfaces.Game.GeneratedEnemies;
    using Domain.Entities.Game.ManyToMany;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class GeneratedEnemyCommands : BaseService, IGeneratedEnemyCommands
    {
        public GeneratedEnemyCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Attack(long attackerId, long defenderId)
        {
            var attacker = await this.Context.GeneratedEnemies.FindAsync(attackerId);
            var defender = await this.Context.Players.FindAsync(attackerId);

            new Attack(attacker, defender);

            await this.SaveAsync();
        }

        public async Task Defend(long unitId, string operation)
        {
            var enemy = await this.Context.GeneratedEnemies.FindAsync(unitId);
            var action = new Defend();

            if (operation == "execute")
            {
                action.Execute(enemy);
            }
            else
            {
                action.Stop(enemy);
            }

            await this.SaveAsync();
        }

        public async Task Die(long victimId, long killerId)
        {
            var victim = await this.Context.GeneratedEnemies.FindAsync(victimId);
            var killer = await this.Context.Players.FindAsync(killerId);

            new Death(victim, killer);
            killer.XP += victim.XPReward;

            this.Context.GeneratedEnemies.Remove(victim);

            await this.SaveAsync();
        }

        public async Task Regenerate(long unitId)
        {
            new Regenerate(await this.Context.GeneratedEnemies.FindAsync(unitId));

            await this.SaveAsync();
        }

        public async Task SpellCast(long id, long playerId)
        {
            var enemy = await this.Context.GeneratedEnemies.FindAsync(id);
            var player = await this.Context.Players.FindAsync(id);
        }

        public async Task Generate(int refLevel)
        {
            var baseEnemies = await this.Context.Enemies.AsNoTracking().ToArrayAsync();

            var baseEnemy = baseEnemies[new Random().Next(baseEnemies.Length)];

            var generatedEnemyId = this.Context.GeneratedEnemies.Add(new StatSetter().EnemyStatSet(baseEnemy, refLevel)).Entity.Id;

            var dbSpells = this.Context.Spells.Where(s => s.EnemyId == baseEnemy.Id).AsNoTracking();

            foreach (var spell in dbSpells)
            {
                this.Context.GeneratedEnemiesSpells.Add(new GeneratedEnemySpells
                {
                    GeneratedEnemyId = generatedEnemyId,
                    SpellId = spell.Id,
                });
            }

            await this.SaveAsync();
        }
    }
}
