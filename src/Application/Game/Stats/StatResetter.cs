namespace Application.Game.Stats
{
    using Domain.Entities.Game.Units;

    public class StatResetter
    {
        public void Execute(Player player) 
        {
            player.CurrentHP = player.MaxHP;
            player.CurrentHealthRegen = player.HealthRegen;
            player.CurrentMana = player.MaxMana;
            player.CurrentManaRegen = player.ManaRegen;
            player.CurrentAttackPower = player.AttackPower;
            player.CurrentAttackPower = player.AttackSpeed;
            player.CurrentMagicPower = player.MagicPower;
            player.CurrentMovementSpeed = player.MovementSpeed;
            player.CurrentTenacity = player.Tenacity;
            player.CurrentCritChance = player.CritChance;
            player.CurrentArmor = player.Armor;
            player.CurrentResistance = player.Resistance;
        }
    }
}
