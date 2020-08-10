namespace Application.Common.Register_Services
{
    using Application.Services.Common.Identity;
    using Application.Services.Game.Enemies;
    using Application.Services.Game.GeneratedEnemies;
    using Application.Services.Game.Items;
    using Application.Services.Game.Players;
    using Application.Services.Game.Spells;
    using Application.Services.Interfaces.Game.Enemies;
    using Application.Services.Interfaces.Game.GeneratedEnemies;
    using Application.Services.Interfaces.Game.Items;
    using Application.Services.Interfaces.Game.Players;
    using Application.Services.Interfaces.Game.Spells;
    using Application.Services.Interfaces.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ServiceRegister
    {
        public ServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUserCommands, UserCommands>();
            services.AddScoped<IUserQueries, UserQueries>();

            services.AddScoped<IEnemyCommands, EnemyCommands>();
            services.AddScoped<IEnemyQueries, EnemyQueries>();

            services.AddScoped<IGeneratedEnemyCommands, GeneratedEnemyCommands>();
            services.AddScoped<IGeneratedEnemyQueries, GeneratedEnemyQueries>();

            services.AddScoped<IItemCommands, ItemCommands>();
            services.AddScoped<IItemQueries, ItemQueries>();

            services.AddScoped<IPlayerCommands, PlayerCommands>();
            services.AddScoped<IPlayerQueries, PlayerQueries>();

            services.AddScoped<ISpellCommands, SpellCommands>();
            services.AddScoped<ISpellQueries, SpellQueries>();

        }
    }
}
