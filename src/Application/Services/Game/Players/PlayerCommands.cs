namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Players.Models;
    using Application.Services.Interfaces.Game.Players;
    using System.Threading.Tasks;

    public class PlayerCommands : BaseService, IPlayerCommands
    {
        public PlayerCommands(IPawContext context)
            : base(context)
        {
        }

        public Task Create(PlayerInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(long id, PlayerInputModel input)
        {
            throw new System.NotImplementedException();
        }
    }
}
