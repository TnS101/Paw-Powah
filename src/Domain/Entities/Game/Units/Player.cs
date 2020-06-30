﻿namespace Domain.Entities.Game.Units
{
    using Domain.Entities.Game.Combat;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using System.Collections.Generic;

    public class Player : IUnit
    {
        public Player()
        {
            this.PlayerAmulets = new HashSet<PlayerAmulets>();
            this.PlayerArmors = new HashSet<PlayerArmors>();
            this.PlayerConsumeables = new HashSet<PlayerConsumeables>();
            this.PlayerWeapons = new HashSet<PlayerWeapons>();
            this.PlayerSpells = new HashSet<PlayerSpells>();
        }

        public long Id { get; set; }

        public int KindId { get; set; }

        public Kind Kind { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public double MaxHP { get; set; }

        public double CurrentHP { get; set; }

        public double MaxMana { get; set; }

        public double CurrentMana { get; set; }

        public double AttackPower { get; set; }

        public double MagicPower { get; set; }

        public double HealthRegen { get; set; }

        public double ManaRegen { get; set; }

        public double CritChance { get; set; }

        public double AttackSpeed { get; set; }

        public double MovementSpeed { get; set; }

        public double Tenacity { get; set; }

        public int InventoryCapacity { get; set; }

        public bool HelmetIsEquipped { get; set; }

        public bool ChestIsEquipped { get; set; }

        public bool LeggingsAreEquipped { get; set; }

        public bool BootsAreEquipped { get; set; }

        public bool IsStunned { get; set; }

        public bool IsSilenced { get; set; }

        public bool IsRooted { get; set; }

        public bool IsConfused { get; set; }

        public bool IsFeared { get; set; }

        public int Gold { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public double Armor { get; set; }

        public double Resistance { get; set; }

        public ICollection<PlayerAmulets> PlayerAmulets { get; set; }

        public ICollection<PlayerArmors> PlayerArmors { get; set; }

        public ICollection<PlayerConsumeables> PlayerConsumeables { get; set; }

        public ICollection<PlayerWeapons> PlayerWeapons { get; set; }

        public ICollection<PlayerSpells> PlayerSpells { get; set; }

        public string ImagePath { get; set; }
    }
}