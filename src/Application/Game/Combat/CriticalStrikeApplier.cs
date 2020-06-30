namespace Application.Game.Combat
{
    using System;

    public class CriticalStrikeApplier
    {
        public int Execute(double critChance)
        {
            return new Random().Next(0, 101) <= (int)critChance ? 2 : 1;
        }
    }
}
