namespace Application.Services.Interfaces.Game.Players
{
    using Application.Services.Game.Players.Models;

    public interface IPlayerQueries : IQuery<PlayerFullViewModel, PlayerMinViewModel>, ISorted<PlayerMinViewModel>
    {
    }
}
