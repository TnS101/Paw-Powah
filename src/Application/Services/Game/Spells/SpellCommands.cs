namespace Application.Services.Game.Spells
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Spells;

    public class SpellCommands : BaseService, ISpellCommands
    {
        public SpellCommands(IPawContext context)
            : base(context)
        {
        }
    }
}
