namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Services.Game.Enemies.Models;
    using System.Threading.Tasks;

    public interface IEnemyCommands : ICommand<EnemyInputModel>
    {
        Task Generate(IPawContext context, int refLevel);

        Task Die(long id, long playerId);

        Task Attack(long attackerId, long targetId);

        Task SpellCast(long casterId, long targetId);
    }
}
