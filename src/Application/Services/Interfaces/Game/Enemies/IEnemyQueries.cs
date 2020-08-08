namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Services.Game.Enemies.Models;
    using System.Threading.Tasks;

    public interface IEnemyQueries : IQuery<EnemyFullViewModel, EnemyMinViewModel>
    {
        Task<GeneratedEnemyViewModel> GetGeneratedEnemy(long id);
    }
}
