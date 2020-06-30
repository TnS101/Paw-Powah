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

        Task Create(string name, double maxHP, double maxMana, double attackPower, double magicPower, double healthRegen, double manaRegen, double critChance
            , double attackSpeed , double movementSpeed, double tenacity, double armor, double resistance, string imagePath);

        Task Delete(long id);

        Task Update(long id, string name, double maxHP, double maxMana, double attackPower, double magicPower, double healthRegen, double manaRegen, double critChance
            , double attackSpeed, double movementSpeed, double tenacity, double armor, double resistance, string imagePath);
    }
}
