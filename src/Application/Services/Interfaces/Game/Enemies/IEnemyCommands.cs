namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Common.Interfaces;
    using System.Threading.Tasks;

    public interface IEnemyCommands
    {
        Task Generate(IPawContext context, int refLevel);

        Task Die(long id, long playerId);

        Task Attack(long attackerId, long targetId);

        Task SpellCast(long casterId, long targetId);
    }
}
