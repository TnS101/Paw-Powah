namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Spells.Models;
    using Application.Services.Interfaces.Game.Spells;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SpellQueries : MapService<SpellFullViewModel, SpellMinViewModel>, ISpellQueries
    {
        public SpellQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }

        public async Task<IEnumerable<SpellMinViewModel>> GetAll()
        {
            return await this.MapCollection(this.Context.Spells);
        }

        public async Task<SpellFullViewModel> GetInfo(long id)
        {
            return this.MapInfo(await this.Context.Spells.FindAsync(id));
        }

        public async Task<IEnumerable<SpellMinViewModel>> GetPlayerSpells(long playerId)
        {
            return await this.MapCollection(this.Context.PlayersSpells.Where(p => p.PlayerId == playerId).Select(s => s.Spell));
        }
    }
}
