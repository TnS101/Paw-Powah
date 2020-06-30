namespace Domain.Entities.Game.Items
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class Consumeable : IItem
    {
        public Consumeable()
        {
            this.PlayerConsumeables = new HashSet<PlayerConsumeables>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string StatRegenType { get; set; }

        public double RegenAmount { get; set; }

        public int Charges { get; set; }

        public int ConsumeDuration { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public double HitBoxX { get; set; }

        public double HitBoxY { get; set; }

        public ICollection<PlayerConsumeables> PlayerConsumeables { get; set; }
    }
}
