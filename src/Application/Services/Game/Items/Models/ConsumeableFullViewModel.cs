namespace Application.Services.Game.Items.Models
{
    public class ConsumeableFullViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StatRegenType { get; set; }

        public double RegenAmount { get; set; }

        public int Charges { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public string ImagePath { get; set; }
    }
}
