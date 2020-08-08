namespace Application.Services.Game.Players
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Players.Models;
    using Application.Services.Interfaces.Game.Players;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerQueries : MapService, IPlayerQueries
    {
        public PlayerQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<IEnumerable<PlayerMinViewModel>> GetAll()
        {
            return await this.Context.Players.ProjectTo<PlayerMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync();
        }

        public async Task<PlayerFullViewModel> GetInfo(long id)
        {
            return this.Mapper.Map<PlayerFullViewModel>(await this.Context.Players.FindAsync(id));
        }
    }
}
