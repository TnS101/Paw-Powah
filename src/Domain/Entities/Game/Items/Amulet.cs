namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class Amulet : IItem, IEquipableItem
    {
        public Amulet()
        {
            this.PlayerAmulets = new HashSet<PlayerAmulets>();
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

        public string BuffStatType { get; set; }

        public double BuffAmount { get; set; }

        public double BuffDuration { get; set; }

        public double Cooldown { get; set; }

        public ICollection<PlayerAmulets> PlayerAmulets { get; set; }
    }
}
