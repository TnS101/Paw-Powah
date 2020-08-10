namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Query_Helpers;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Enemies.Models;
    using Application.Services.Interfaces.Game.Enemies;
    using AutoMapper;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EnemyQueries : MapService<EnemyFullViewModel, EnemyMinViewModel>, IEnemyQueries
    {
        public EnemyQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }

        public async Task<IEnumerable<EnemyMinViewModel>> GetAll()
        {
            return await this.MapCollection(this.Context.Enemies);
        }

        public async Task<EnemyFullViewModel> GetInfo(long id)
        {
            return this.MapInfo(await this.Context.Enemies.FindAsync(id));
        }

        

        public async Task<IEnumerable<EnemyMinViewModel>> GetSorted(string criteria, string condition, double value)
        {
            return await this.MapCollection(new QuerySorter<Enemy>().Execute(this.Context.Enemies, criteria, condition, value));
        }
    }
}
