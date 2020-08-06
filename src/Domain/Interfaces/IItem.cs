namespace Domain.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }

        string Name { get; set; }

        int BuyPrice { get; set; }

        int SellPrice { get; set; }

        string ImagePath { get; set; }
    }
}
