namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Players;
    using AutoMapper;

    public class PlayerQueries : MapService, IPlayerQueries
    {
        public PlayerQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }
    }
}
