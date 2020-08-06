namespace Application.Services.Interfaces.Game.Items
{
    using Application.Services.Game.Items.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemQueries
    {
        Task<IEnumerable<ItemMinViewModel>> GetAll();

        Task<EquipableFullViewModel> GetEquipable(int id);

        Task<ConsumeableFullViewModel> GetConsumeable(int id);
    }
}
