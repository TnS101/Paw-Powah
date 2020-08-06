namespace Application.Services.Game.Items.Models
{
    public class ItemInputModel
    {
        public string Name { get; set; }

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

        public string StatType { get; set; }

        public double StatAmount { get; set; }

        public int Charges { get; set; }

        public int Cooldown { get; set; }

        public double BuffDuration { get; set; }

        public string ImagePath { get; set; }
    }
}
