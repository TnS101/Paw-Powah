namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Enemies;

    public class EnemyCommands : BaseService, IEnemyCommands
    {
        public EnemyCommands(IPawContext context)
            :base(context)
        {
        }
    }
}
