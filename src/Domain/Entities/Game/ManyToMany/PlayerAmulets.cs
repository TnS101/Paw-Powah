namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public class PlayerAmulets
    {
        public long PlayerId { get; set; }

        public Player Player { get; set; }

        public int AmuletId { get; set; }

        public Amulet Amulet { get; set; }

        public int Count { get; set; }
    }
}
