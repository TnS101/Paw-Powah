namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Stats;
    using Application.Services.Game.Players.Models;
    using Application.Services.Interfaces.Game.Players;
    using Domain.Entities.Game.Units;
    using System.Threading;
    using System.Threading.Tasks;

    public class PlayerCommands : BaseService, IPlayerCommands
    {
        public PlayerCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Create(PlayerInputModel input)
        {
            var player = new Player { Name = input.Name, ClassId = input.ClassId, KindId = input.KindId };

            var battleClass = await this.Context.BattleClasses.FindAsync(input.ClassId);
            var kind = await this.Context.Kinds.FindAsync(input.KindId);

            new StatSet().PlayerStatSet(battleClass, player, kind.IncreaseStatType, kind.IncreaseAmount);

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Delete(long id)
        {
            this.Context.Players.Remove(await this.Context.Players.FindAsync(id));

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Update(long id, PlayerInputModel input)
        {
            var player = new Player { Name = input.Name, ClassId = input.ClassId, KindId = input.KindId };

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                player.Name = input.Name;
            }

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }
    }
}
