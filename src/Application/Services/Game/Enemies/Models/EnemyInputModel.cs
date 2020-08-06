namespace Application.Services.Game.Enemies.Models
{
    public class EnemyInputModel
    {
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
    }
}
