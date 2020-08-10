namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Services.Game.Enemies.Models;
    public interface IEnemyQueries : IQuery<EnemyFullViewModel, EnemyMinViewModel>, ISorted<EnemyMinViewModel>
    {
    }
}
