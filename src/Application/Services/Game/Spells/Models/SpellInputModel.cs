namespace Application.Services.Game.Spells.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SpellInputModel
    {
        public int? ClassId { get; set; }

        public int? EnemyId { get; set; }

        public int? KindId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Duration { get; set; }

        public int Ticks { get; set; }

        public double Cooldown { get; set; }
    }
}
