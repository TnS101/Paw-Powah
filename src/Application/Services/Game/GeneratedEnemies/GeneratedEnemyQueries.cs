namespace Application.Services.Game.GeneratedEnemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.GeneratedEnemies.Models;
    using Application.Services.Interfaces.Game.GeneratedEnemies;
    using AutoMapper;
    using System.Threading.Tasks;

    public class GeneratedEnemyQueries : MapService<GeneratedEnemyViewModel, GeneratedEnemyViewModel>,IGeneratedEnemyQueries
    {
        public GeneratedEnemyQueries(Mapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<GeneratedEnemyViewModel> GetInfo(long id)
        {
            return this.MapInfo(await this.Context.GeneratedEnemies.FindAsync(id));
        }
    }
}
