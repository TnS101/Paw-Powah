namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Players;

    public class PlayerCommands : BaseService, IPlayerCommands
    {
        public PlayerCommands(IPawContext context)
            : base(context)
        {

        }
    }
}
