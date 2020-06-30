namespace Domain.Entities.Game.Combat
{
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using System.Collections.Generic;

    public class Spell
    {
        public Spell()
        {
            this.PlayerSpells = new HashSet<PlayerSpells>();
            this.GeneratedEnemySpells = new HashSet<GeneratedEnemySpells>();
        }

        public int Id { get; set; }

        public int? ClassId { get; set; }

        public Class Class { get; set; }

        public int? EnemyId { get; set; }

        public Enemy Enemy { get; set; }

        public int? KindId { get; set; }

        public Kind Kind { get; set; }

        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Duration { get; set; }

        public int Ticks { get; set; }

        public double Cooldown { get; set; }

        public ICollection<PlayerSpells> PlayerSpells { get; set; }

        public ICollection<GeneratedEnemySpells> GeneratedEnemySpells { get; set; }
    }
}
