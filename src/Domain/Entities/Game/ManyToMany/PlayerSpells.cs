namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Units;

    public class PlayerSpells
    {
        public long PlayerId { get; set; }

        public Player Player { get; set; }

        public int SpellId { get; set; }

        public Spell Spell { get; set; }
    }
}
