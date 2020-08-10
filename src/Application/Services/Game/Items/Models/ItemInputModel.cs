namespace Application.Services.Game.Items.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ItemInputModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Slot { get; set; }

        public double HealthIncrease { get; set; }

        public double ManaIncrease { get; set; }

        public double HealthRegenIncrease { get; set; }

        public double ManaRegenIncrease { get; set; }

        public double CritChanceIncrease { get; set; }

        public double MovementSpeedIncrease { get; set; }

        public double AttackSpeedIncrease { get; set; }

        public double ArmorValue { get; set; }

        public double ResistanceValue { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public double Damage { get; set; }

        public double AttackSpeed { get; set; }

        public string StatRegenType { get; set; }

        public double RegenAmount { get; set; }

        public int Charges { get; set; }

        public double Cooldown { get; set; }

        [Required]
        [StringLength(50)]
        public string BuffStatType { get; set; }

        public double BuffDuration { get; set; }

        [Required]
        [StringLength(200)]
        public string ImagePath { get; set; }
    }
}
