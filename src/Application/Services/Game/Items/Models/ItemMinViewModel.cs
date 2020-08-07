namespace Application.Services.Game.Items.Models
{
    public class ItemMinViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BuyPrice { get; set; }

        public int SellPrice { get; set; }

        public string ImagePath { get; set; }

        public int Count { get; set; }
    }
}
