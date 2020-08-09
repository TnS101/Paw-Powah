namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Query_Helpers;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Players.Models;
    using Application.Services.Interfaces.Game.Players;
    using AutoMapper;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerQueries : MapService<PlayerFullViewModel, PlayerMinViewModel>, IPlayerQueries
    {
        public PlayerQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<IEnumerable<PlayerMinViewModel>> GetAll()
        {
            return await this.MapCollection(this.Context.Players);
        }

        public async Task<IEnumerable<PlayerMinViewModel>> GetSorted(string criteria, string condition, double value)
        {
            return await this.MapCollection(new QuerySorter<Player>().Execute(this.Context.Players, criteria, condition, value));
        }

        public async Task<PlayerFullViewModel> GetInfo(long id)
        {
            return this.MapInfo(await this.Context.Players.FindAsync(id));
        }
    }
}
