﻿namespace Application.Services.Game.Enemies
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Game.Stats;
    using Application.Services.Game.Enemies.Models;
    using Application.Services.Interfaces.Game.Enemies;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EnemyCommands : BaseService, IEnemyCommands
    {
        public EnemyCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Create(EnemyInputModel input)
        {
            this.Context.Enemies.Add(new Enemy
            {
                Name = input.Name,
                MaxHP = input.MaxHP,
                MaxMana = input.MaxMana,
                AttackPower = input.AttackPower,
                MagicPower = input.MagicPower,
                HealthRegen = input.HealthRegen,
                ManaRegen = input.ManaRegen,
                CritChance = input.CritChance,
                AttackSpeed = input.AttackSpeed,
                MovementSpeed = input.MovementSpeed,
                Tenacity = input.Tenacity,
                Armor = input.Armor,
                Resistance = input.Resistance,
                ImagePath = input.ImagePath,
            });

            await this.SaveAsync();
        }

        public async Task Delete(long id)
        {
            this.Context.Enemies.Remove(await this.Context.Enemies.FindAsync(id));

            await this.SaveAsync();
        }

        public async Task Update(long id, EnemyInputModel input)
        {
            var enemy = await this.Context.Enemies.FindAsync(id);

            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                enemy.Name = input.Name;
            }

            if (input.MaxHP > 0)
            {
                enemy.MaxHP = input.MaxHP;
            }

            if (input.MaxMana > 0)
            {
                enemy.MaxMana = input.MaxMana;
            }

            if (input.HealthRegen > 0)
            {
                enemy.HealthRegen = input.HealthRegen;
            }

            if (input.ManaRegen > 0)
            {
                enemy.ManaRegen = input.ManaRegen;
            }

            if (input.AttackPower > 0)
            {
                enemy.AttackPower = input.AttackPower;
            }

            if (input.MagicPower > 0)
            {
                enemy.MagicPower = input.MagicPower;
            }

            if (input.Armor > 0)
            {
                enemy.Armor = input.Armor;
            }

            if (input.Resistance > 0)
            {
                enemy.Resistance = input.Resistance;
            }

            if (input.CritChance > 0)
            {
                enemy.CritChance = input.CritChance;
            }

            this.Context.Enemies.Update(enemy);

            await this.SaveAsync();
        }
    }
}
