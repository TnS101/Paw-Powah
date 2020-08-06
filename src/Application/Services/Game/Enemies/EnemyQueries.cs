namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Enemies.Models;
    using Application.Services.Interfaces.Game.Enemies;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EnemyQueries : MapService, IEnemyQueries
    {
        public EnemyQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }

        public async Task<IEnumerable<Enemy>> GetAll()
        {
            return await this.Context.Enemies.ProjectTo<EnemyMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<Enemy> GetInfo(long id)
        {
            return await this.Context.Enemies.FindAsync((int)id);
        }

        public async Task<GeneratedEnemyViewModel> GetGeneratedEnemy(long id)
        {
            return Mapper.Map<GeneratedEnemyViewModel>(await this.Context.GeneratedEnemies.FindAsync(id));
        }
    }
}
