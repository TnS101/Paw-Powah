namespace Domain.Entities.Game.ManyToMany
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.Units;

    public class GeneratedEnemySpells
    {
        public long GeneratedEnemyId { get; set; }

        public GeneratedEnemy GeneratedEnemy { get; set; }

        public int SpellId { get; set; }

        public Spell Spell { get; set; }
    }
}
