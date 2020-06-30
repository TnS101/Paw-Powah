namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Services.Game.Enemies.ViewModels;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEnemyQueries
    {
        Task<GeneratedEnemyViewModel> GetGeneratedEnemy(long id);

        Task<IEnumerable<EnemyMinViewModel>> GetAllEnemies();

        Task<Enemy> GetEnemyInfo(int id);
    }
}
