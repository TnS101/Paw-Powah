namespace Application.Services.Game.Spells.Models
{
    using Domain.Entities.Game.Combat;

    public class SpellFullViewModel : Spell
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public string EnemyName { get; set; }

        public string KindName { get; set; }

        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Duration { get; set; }

        public int Ticks { get; set; }

        public double Cooldown { get; set; }
    }
}
