namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Combat;
    using Application.Game.Stats;
    using Application.Services.Game.Players.Models;
    using Application.Services.Interfaces.Game.Players;
    using Domain.Entities.Game.Units;
    using System.Threading.Tasks;

    public class PlayerCommands : BaseService, IPlayerCommands
    {
        public PlayerCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Attack(long attackerId, long targetId)
        {
            var attacker = await this.Context.Players.FindAsync(attackerId);
            var defender = await this.Context.GeneratedEnemies.FindAsync(targetId);

            new Attack(attacker, defender);
        }

        public async Task Defend(long unitId, string operation)
        {
            var player = await this.Context.Players.FindAsync(unitId);
            var action = new Defend();

            if (operation == "execute")
            {
                action.Execute(player);
            }
            else
            {
                action.Stop(player);
            }

            await this.SaveAsync();
        }

        public async Task Die(long victimId, long killerId)
        {
            var victim = await this.Context.Players.FindAsync(victimId);
            var killer = await this.Context.GeneratedEnemies.FindAsync(killerId);

            new Death(victim, killer);

            await this.SaveAsync();
        }

        public async Task Regenerate(long unitId)
        {
            new Regenerate(await this.Context.Players.FindAsync(unitId));

            await this.SaveAsync();
        }

        public Task SpellCast(long casterId, long targetId)
        {
            throw new System.NotImplementedException();
        }

        public async Task Create(PlayerInputModel input)
        {
            var player = new Player { Name = input.Name, ClassId = input.ClassId, KindId = input.KindId };

            var battleClass = await this.Context.BattleClasses.FindAsync(input.ClassId);
            var kind = await this.Context.Kinds.FindAsync(input.KindId);

            this.Context.Players.Add(new StatSetter().PlayerStatSet(battleClass, player, kind));

            await this.SaveAsync();
        }

        public async Task Update(long id, PlayerInputModel input)
        {
            var player = new Player { Name = input.Name, ClassId = input.ClassId, KindId = input.KindId };

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                player.Name = input.Name;
            }

            await this.SaveAsync();
        }

        public async Task Delete(long id)
        {
            this.Context.Players.Remove(await this.Context.Players.FindAsync(id));

            await this.SaveAsync();
        }
    }
}
