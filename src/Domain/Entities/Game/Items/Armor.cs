namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class Armor : IItem, IEquipableItem
    {
        public Armor()
        {
            this.PlayerArmors = new HashSet<PlayerArmors>();
        }

        public int Id { get; set; }

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

        public ICollection<PlayerArmors> PlayerArmors { get; set; }
    }
}
