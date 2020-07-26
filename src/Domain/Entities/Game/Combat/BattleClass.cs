namespace Domain.Entities.Game.Combat
{
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class BattleClass
    {
        public BattleClass()
        {
            this.Spells = new HashSet<Spell>();
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double CritChance { get; set; }

        public double Armor { get; set; }

        public double Resistance { get; set; }

        public double AttackSpeed { get; set; }

        public double MovementSpeed { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Spell> Spells { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
