namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Spells;
    using AutoMapper;
    using Domain.Entities.Game.Combat;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SpellQueries : MapService, ISpellQueries
    {
        public SpellQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }

        public Task<IEnumerable<Spell>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Spell> GetInfo(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
