namespace Domain.Entities.Game.Units
{
    using Domain.Entities.Game.Combat;
    using System.Collections.Generic;

    public class Enemy
    {
        public Enemy()
        {
            this.Spells = new HashSet<Spell>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public double MaxHP { get; set; }

        public double MaxMana { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double CritChance { get; set; }

        public double AttackSpeed { get; set; }

        public double MovementSpeed { get; set; }

        public double Tenacity { get; set; }

        public double Armor { get; set; }

        public double Resistance { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Spell> Spells { get; set; }
    }
}
