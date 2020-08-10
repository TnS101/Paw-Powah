namespace Application.Services.Interfaces.Game.Players
{
    using Application.Services.Game.Players.Models;

    public interface IPlayerCommands : ICommand<PlayerInputModel>, ICombat
    {
    }
}
