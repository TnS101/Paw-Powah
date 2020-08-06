namespace Application.Services.Game.Items.Models
{
    using System.Collections.Generic;

    public class EquipableFullViewModel
    {
        public EquipableFullViewModel()
        {
            this.SpecificProps = new HashSet<long>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public double HealthIncrease { get; set; }

        public double ManaIncrease { get; set; }

        public double HealthRegenIncrease { get; set; }

        public double ManaRegenIncrease { get; set; }

        public double CritChanceIncrease { get; set; }

        public double MovementSpeedIncrease { get; set; }

        public double AttackSpeedIncrease { get; set; }

        public string ImagePath { get; set; }
        
        public IEnumerable<long> SpecificProps { get; set; }
    }
}
