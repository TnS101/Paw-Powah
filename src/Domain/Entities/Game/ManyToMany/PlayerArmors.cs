namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public class PlayerArmors
    {
        public long PlayerId { get; set; }

        public Player Player { get; set; }

        public int ArmorId { get; set; }

        public Armor Armor { get; set; }

        public int Amount { get; set; }
    }
}
