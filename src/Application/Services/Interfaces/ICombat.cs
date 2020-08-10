namespace Application.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICombat
    {
        Task Attack(long attackerId, long targetId);

        Task Defend(long unitId);

        Task Regenerate(long unitId);

        Task SpellCast(long casterId, long targetId);

        Task Die(long victimId, long killerId);
    }
}
