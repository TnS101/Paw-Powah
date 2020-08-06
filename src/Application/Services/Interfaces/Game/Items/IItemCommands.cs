namespace Application.Services.Interfaces.Game.Items
{
    using Application.Services.Game.Items.Models;
    using System.Threading.Tasks;

    public interface IItemCommands
    {
        Task Create(ItemInputModel input);

        Task Update(ItemInputModel input, int id);
    }
}
