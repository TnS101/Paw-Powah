namespace Application.Services.Game.Players.Models
{
    public class PlayerMinViewModel
    {
        public string Name { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double МaxMana{ get; set; }

        public double CurrentMana{ get; set; }

        public int Level { get; set; }

        public string ImagePath { get; set; }
    }
}
