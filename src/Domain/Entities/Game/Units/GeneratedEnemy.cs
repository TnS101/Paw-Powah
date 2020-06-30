namespace Domain.Entities.Game.Units
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class GeneratedEnemy : IUnit
    {
        public GeneratedEnemy()
        {
            this.GeneratedEnemySpells = new HashSet<GeneratedEnemySpells>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double Armor { get; set; }

        public double Resistance { get; set; }

        public double CritChance { get; set; }

        public double AttackSpeed { get; set; }

        public double MovementSpeed { get; set; }

        public double Tenacity { get; set; }

        public bool IsStunned { get; set; }

        public bool IsSilenced { get; set; }

        public bool IsRooted { get; set; }

        public bool IsConfused { get; set; }

        public bool IsFeared { get; set; }

        public int Gold { get; set; }

        public string ImagePath { get; set; }

        public ICollection<GeneratedEnemySpells> GeneratedEnemySpells { get; set; }
    }
}
