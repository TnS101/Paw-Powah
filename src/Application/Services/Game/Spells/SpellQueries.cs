namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Spells;
    using AutoMapper;

    public class SpellQueries : MapService, ISpellQueries
    {
        public SpellQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {

        }
    }
}
