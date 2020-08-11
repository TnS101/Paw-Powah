namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Query_Helpers;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Spells.Models;
    using Application.Services.Interfaces.Game.Spells;
    using AutoMapper;
    using Domain.Entities.Game.Combat;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SpellQueries : MapService<SpellFullViewModel, SpellMinViewModel>, ISpellQueries
    {
        public SpellQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<IEnumerable<SpellMinViewModel>> GetAll()
        {
            return await this.MapCollection(this.Context.Spells.AsNoTracking());
        }

        public async Task<SpellFullViewModel> GetInfo(long id)
        {
            return this.MapInfo(await this.Context.Spells.FindAsync(id));
        }

        public async Task<IEnumerable<SpellMinViewModel>> GetPlayerSpells(long playerId)
        {
            return await this.MapCollection(this.Context.PlayersSpells.AsNoTracking().Where(p => p.PlayerId == playerId).Select(s => s.Spell));
        }

        public async Task<IEnumerable<SpellMinViewModel>> GetSorted(string criteria, string condition, double value)
        {
            return await this.MapCollection(new QuerySorter<Spell>().Execute(this.Context.Spells.AsNoTracking(), criteria, condition, value));
        }
    }
}
