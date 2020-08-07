namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;

    public class PlayerWeapons
    {
        public long PlayerId { get; set; }

        public Player Player { get; set; }

        public int WeaponId { get; set; }

        public Weapon Weapon { get; set; }

        public int Amount { get; set; }
    }
}
