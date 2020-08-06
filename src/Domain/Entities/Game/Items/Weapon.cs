namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class Weapon : IItem, IEquipableItem
    {
        public Weapon()
        {
            this.PlayerWeapons = new HashSet<PlayerWeapons>();
        }

        public int Id { get;set; }

        public string Name { get;set; }

        public double AttackSpeed { get; set; }

        public double Damage { get; set; }

        public int BuyPrice { get;set; }

        public int SellPrice { get;set; }

        public double HealthIncrease { get;set; }

        public double ManaIncrease { get;set; }

        public double HealthRegenIncrease { get;set; }

        public double ManaRegenIncrease { get;set; }

        public double CritChanceIncrease { get;set; }

        public double MovementSpeedIncrease { get;set; }

        public double AttackSpeedIncrease { get;set; }

        public string ImagePath { get; set; }

        public ICollection<PlayerWeapons> PlayerWeapons { get; set; }
    }
}
