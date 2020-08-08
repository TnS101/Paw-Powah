namespace Application.Services.Interfaces.Game.Spells
{
    using Application.Services.Game.Spells.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISpellQueries : IQuery<SpellFullViewModel, SpellMinViewModel>
    {
        Task<IEnumerable<SpellMinViewModel>> GetPlayerSpells(long playerId);
    }
}
