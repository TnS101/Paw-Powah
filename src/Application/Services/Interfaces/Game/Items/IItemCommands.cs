namespace Application.Services.Interfaces.Game.Items
{
    using Application.Services.Game.Items.Models;
    using System.Threading.Tasks;

    public interface IItemCommands
    {
        Task Delete(string type, int id);

        Task Update(string type, int id, ItemInputModel input);
    }
}
