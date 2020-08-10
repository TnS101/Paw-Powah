namespace Application.Services.Interfaces.Game.GeneratedEnemies
{
    using Application.Common.Interfaces;
    using System.Threading.Tasks;

    public interface IGeneratedEnemyCommands : ICombat
    {
        Task Generate(int refLevel);
    }
}
