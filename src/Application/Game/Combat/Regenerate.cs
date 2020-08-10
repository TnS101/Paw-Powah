namespace Application.Game.Combat
{
    using Domain.Interfaces;

    public class Regenerate
    {
        public Regenerate(IUnit unit)
        {
            if (unit.CurrentHP + unit.CurrentHealthRegen >= unit.MaxHP)
            {
                unit.CurrentHP = unit.MaxHP;
            }
            else
            {
                unit.CurrentHP += unit.CurrentHealthRegen;
            }

            if (unit.CurrentMana + unit.CurrentManaRegen >= unit.MaxMana)
            {
                unit.CurrentMana = unit.MaxMana;
            }
            else
            {
                unit.CurrentMana += unit.CurrentManaRegen;
            }
        }
    }
}
