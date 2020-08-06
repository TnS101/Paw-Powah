﻿namespace Application.Services.Interfaces.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Services.Game.Enemies.Models;
    using System.Threading.Tasks;

    public interface IEnemyCommands
    {
        Task Generate(IPawContext context, int refLevel);

        Task Die(long id, long playerId);

        Task Attack(long attackerId, long targetId);

        Task SpellCast(long casterId, long targetId);

        Task Create(EnemyInputModel input);

        Task Delete(long id);

        Task Update(long id, EnemyInputModel input);
    }
}
