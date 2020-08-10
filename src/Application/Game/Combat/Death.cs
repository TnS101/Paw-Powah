namespace Application.Game.Combat
{
    using Domain.Interfaces;

    public class Death
    {
        public Death(IUnit victim, IUnit killer)
        {
            int gold;

            if (victim.Type == "player")
            {
                killer.CurrentHP += killer.MaxHP * 0.3;
                killer.MaxHP += killer.MaxHP * 0.3;

                if (killer.CurrentHP > killer.MaxHP)
                {
                    killer.CurrentHP = killer.MaxHP;
                }

                gold = (int)(victim.Gold * 0.1);

                killer.Gold += gold;
                victim.Gold -= gold;
            }
            else
            {
                killer.Gold += victim.Gold;
            }
        }
    }
}
