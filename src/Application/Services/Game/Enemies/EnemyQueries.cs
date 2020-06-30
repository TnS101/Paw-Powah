namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Enemies.ViewModels;
    using Application.Services.Interfaces.Game.Enemies;
    using AutoMapper;
    using System.Threading.Tasks;

    public class EnemyQueries : MapService, IEnemyQueries
    {
        public EnemyQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }

        public async Task<EnemyMinViewModel> GetEnemy(long id)
        {
            return Mapper.Map<EnemyMinViewModel>(await this.Context.GeneratedEnemies.FindAsync(id));
        }
    }
}
