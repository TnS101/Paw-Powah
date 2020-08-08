namespace Application.Services.Game.Spells.Models
{
    public class SpellMinViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double ManaRequirement { get; set; }

        public double Cooldown { get; set; }
    }
}
