namespace Application.Game.Generators
{
    using Application.Common.Interfaces;
    using Application.Game.Stats;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnemyGenerator
    {
        public async Task<GeneratedEnemy> Generate(IPawContext context, int refLevel)
        {
            var baseEnemies = await context.Enemies.AsNoTracking().ToArrayAsync();

            var baseEnemy = baseEnemies[new Random().Next(baseEnemies.Length)];

            var generatedEnemy = context.GeneratedEnemies.Add(new StatSet().EnemyStatSet(baseEnemy, refLevel)).Entity;

            var dbSpells = context.Spells.Where(s => s.EnemyId == baseEnemy.Id).AsNoTracking();

            foreach (var spell in dbSpells)
            {
                context.GeneratedEnemiesSpells.Add(new GeneratedEnemySpells
                {
                    GeneratedEnemyId = generatedEnemy.Id,
                    SpellId = spell.Id,
                });
            }

            
            await context.SaveChangesAsync(CancellationToken.None);

            return generatedEnemy;
        }
    }
}
