namespace Application.Game.Combat
{
    using Domain.Interfaces;

    public class Attack
    {
        public Attack(IUnit attacker, IUnit defender)
        {
            defender.CurrentHP -= attacker.AttackPower * new CriticalStrikeApplier().Execute(attacker.AttackPower) - defender.Armor;
        }
    }
}
