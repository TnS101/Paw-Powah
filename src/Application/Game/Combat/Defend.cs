namespace Application.Game.Combat
{
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using Domain.Interfaces;
    using System.Threading;
    using System.Threading.Tasks;

    public class Defend
    {
        public async Task Execute(IUnit unit, IPawContext context)
        {
            unit = await this.FindUnit(unit, context);

            unit.Armor += unit.Armor * 0.4;
            unit.MovementSpeed -= unit.MovementSpeed * 0.3;

            await context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Stop(IUnit unit, IPawContext context)
        {
            unit = await this.FindUnit(unit, context);

            unit.Armor -= unit.Armor * 0.4;
            unit.MovementSpeed += unit.MovementSpeed * 0.3;

            await context.SaveChangesAsync(CancellationToken.None);
        }

        private async Task<IUnit> FindUnit(IUnit unit, IPawContext context)
        {
            if (unit.GetType() == typeof(Player))
            {
                unit = await context.Players.FindAsync(unit.Id);
            }
            else
            {
                unit = await context.GeneratedEnemies.FindAsync(unit.Id);
            }

            return unit;
        }
    }
}
