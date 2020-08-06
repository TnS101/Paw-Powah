namespace Application.Services.Game.Spells.Models
{
    public class SpellInputModel
    {
        public int? ClassId { get; set; }

        public int? EnemyId { get; set; }

        public int? KindId { get; set; }

        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Duration { get; set; }

        public int Ticks { get; set; }

        public double Cooldown { get; set; }
    }
}
