namespace Application.Game.Handlers
{
    using Application.Common.Interfaces;
    using Application.Game.Stats;
    using Domain.Entities.Common;
    using Microsoft.EntityFrameworkCore;
    using Quartz;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class VolatileHandler : IJob
    {
        private readonly IVolatileContext volatileContext;
        private readonly IPawContext context;
        public VolatileHandler(IVolatileContext volatileContext, IPawContext context)
        {
            this.volatileContext = volatileContext;
            this.context = context;
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

        public async Task<bool> CheckCD(long unitId, int spellId, IVolatileContext volatileContext)
        {
            if (await volatileContext.Cooldowns.AnyAsync(c => c.UnitId == unitId && c.SpellId == spellId))
            {
                return false;
            }

            return true;
        }

        private async Task BuffHandler(long unitId, string buffType, double buffPower, string operation, IPawContext context)
        {
            var unit = await context.Players.FindAsync(unitId);

            new StatProcessor().Execute(unit, buffType, buffPower, operation);
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var cooldowns = this.volatileContext.Cooldowns.Where(c => c.EndsOn >= DateTime.UtcNow);
            var durations = this.volatileContext.Durations.Where(d => d.EndsOn >= DateTime.UtcNow);

            if (cooldowns.Count() == 0 && durations.Count() == 0)
            {
                return;
            }

            foreach (var duration in durations)
            {
                await this.BuffHandler(duration.UnitId, duration.EffectType, duration.EffectPower, "-", this.context);
            }

            this.volatileContext.Durations.RemoveRange(durations);
            this.volatileContext.Cooldowns.RemoveRange(cooldowns);

            await this.volatileContext.SaveChangesAsync(CancellationToken.None);
        }
    }
}
