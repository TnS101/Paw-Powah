namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Spells.Models;
    using Application.Services.Interfaces.Game.Spells;
    using System.Threading.Tasks;

    public class SpellCommands : BaseService, ISpellCommands
    {
        public SpellCommands(IPawContext context)
            : base(context)
        {
        }

        public Task Create(SpellInputModel input)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(long id, SpellInputModel input)
        {
            throw new System.NotImplementedException();
        }
    }
}
