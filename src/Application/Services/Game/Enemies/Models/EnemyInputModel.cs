namespace Application.Services.Game.Enemies.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EnemyInputModel
    {
        [Required]
        [StringLength(50)]
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

        [Required]
        [StringLength(200)]
        public string ImagePath { get; set; }
    }
}
