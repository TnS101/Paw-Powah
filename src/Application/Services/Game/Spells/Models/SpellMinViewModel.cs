namespace Application.Services.Game.Spells.Models
{
    using Domain.Entities.Game.Combat;

    public class SpellMinViewModel : Spell
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Cooldown { get; set; }
    }
}
