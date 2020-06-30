namespace Application.Game.Handlers
{
    using Application.Common.Interfaces;
    using Application.Game.Stats;
    using Domain.Entities.Common;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class VolatileHandler
    {
        public VolatileHandler()
        {
        }

        public async Task Clear(IVolatileContext volatileContext, IPawContext context)
        {
            var cooldowns = volatileContext.Cooldowns.Where(c => c.EndsOn >= DateTime.UtcNow);
            var durations = volatileContext.Durations.Where(d => d.EndsOn >= DateTime.UtcNow);

            if (cooldowns.Count() == 0 && durations.Count() == 0)
            {
                return;
            }

            foreach (var duration in durations)
            {
                await this.BuffHandler(duration.UnitId, duration.EffectType, duration.EffectPower, "-", context);
            }

            volatileContext.Durations.RemoveRange(durations);
            volatileContext.Cooldowns.RemoveRange(cooldowns);

            await volatileContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task SetCD(long unitId, double cooldownDuration, int spellId, IVolatileContext volatileContext)
        {
            volatileContext.Cooldowns.Add(new Cooldown
            {
                UnitId = unitId,
                SpellId = spellId,
                EndsOn = DateTime.UtcNow.AddSeconds(cooldownDuration),
            });

            await volatileContext.SaveChangesAsync(CancellationToken.None);
        }

        public async Task SetDuration(long unitId, double effectDuration, double effectPower, string effectType, IVolatileContext volatileContext, IPawContext context)
        {
            volatileContext.Durations.Add(new Duration
            {
                UnitId = unitId,
                EffectType = effectType,
                EffectPower = effectPower,
                EndsOn = DateTime.UtcNow.AddSeconds(effectDuration),
            });

            await this.BuffHandler(unitId, effectType, effectPower, "+", context);

            await volatileContext.SaveChangesAsync(CancellationToken.None);
            await context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task CheckCD(long unitId, int spellId, IVolatileContext volatileContext)
        {
            if (await volatileContext.Cooldowns.AnyAsync(c => c.UnitId == unitId && c.SpellId == spellId))
            {
                return;
            }
        }

        private async Task BuffHandler(long unitId, string buffType, double buffPower, string operation, IPawContext context)
        {
            var unit = await context.Players.FindAsync(unitId);

            new CustomStatProcessor().Execute(unit, buffType, buffPower, operation);
        }
    }
}
