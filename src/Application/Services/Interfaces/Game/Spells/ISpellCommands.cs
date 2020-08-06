namespace Application.Services.Interfaces.Game.Spells
{
    using Application.Services.Game.Spells.Models;

    public interface ISpellCommands : ICommand<SpellInputModel>
    {
    }
}
