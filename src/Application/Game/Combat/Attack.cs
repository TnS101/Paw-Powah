namespace Application.Game.Combat
{
    using Domain.Interfaces;

    public class Attack
    {
        public Attack(IUnit attacker, IUnit defender)
        {
            defender.CurrentHP -= attacker.CurrentAttackPower * new CriticalStrikeApplier().Execute(attacker.CurrentAttackPower) - defender.CurrentArmor;
        }
    }
}
