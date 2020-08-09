namespace Application.Services.Interfaces.Game.Items
{
    using Application.Services.Game.Items.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemQueries : ISorted<ItemMinViewModel>
    {
        Task<IEnumerable<ItemMinViewModel>> GetInventory(long playerId);

        Task<EquipableFullViewModel> GetEquipable(int id, string type);

        Task<IEnumerable<EquipableFullViewModel>> GetEquipment(long playerId);

        Task<ConsumeableFullViewModel> GetConsumeable(int id);

        Task<IEnumerable<ItemMinViewModel>> GetAllItems(string type);
    }
}
