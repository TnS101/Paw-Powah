namespace Application.Game.Combat
{
    using Domain.Interfaces;

    public class Defend
    {
        public Defend()
        {
        }

        public void Execute(IUnit unit)
        {
            unit.CurrentArmor += unit.CurrentArmor * 0.4;
            unit.CurrentMovementSpeed -= unit.CurrentMovementSpeed * 0.3;
        }

        public void Stop(IUnit unit)
        {
            unit.CurrentArmor -= unit.CurrentArmor * 0.4;
            unit.CurrentMovementSpeed += unit.CurrentMovementSpeed * 0.3;
        }
    }
}
