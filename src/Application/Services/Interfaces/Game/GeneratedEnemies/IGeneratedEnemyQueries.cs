namespace Application.Services.Interfaces.Game.GeneratedEnemies
{
    using Application.Services.Game.GeneratedEnemies.Models;
    using System.Threading.Tasks;

    public interface IGeneratedEnemyQueries
    {
        Task<GeneratedEnemyViewModel> GetInfo(long id);
    }
}
