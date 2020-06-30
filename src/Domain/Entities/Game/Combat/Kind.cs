namespace Domain.Entities.Game.Combat
{
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Kind
    {
        public Kind()
        {
            this.Players = new HashSet<Player>();
        }

        public int Id { get; set; }

        public int SpellId { get; set; }

        public Spell Spell { get; set; }

        public string Name { get; set; }

        public string IncreaseStatType { get; set; }

        public double IncreaseAmount { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
