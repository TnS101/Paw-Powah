namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Enemies;
    using AutoMapper;

    public class EnemyQueries : MapService, IEnemyQueries
    {
        public EnemyQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }
    }
}
