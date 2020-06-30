namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Services.Game.Enemies.ViewModels;
    using System.Threading.Tasks;

    public interface IEnemyQueries
    {
        Task<EnemyMinViewModel> GetEnemy(long id);
    }
}
