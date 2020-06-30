namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public class PlayerConsumeables
    {
        public long PlayerId { get; set; }

        public Player Player { get; set; }

        public int ConsumeableId { get; set; }

        public Consumeable Consumeable { get; set; }

        public int Count { get; set; }
    }
}
