namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Services.Game.Enemies.Models;
    using Domain.Entities.Game.Units;
    using System.Threading.Tasks;

    public interface IEnemyQueries : IQuery<Enemy>
    {
        Task<GeneratedEnemyViewModel> GetGeneratedEnemy(long id);
    }
}
