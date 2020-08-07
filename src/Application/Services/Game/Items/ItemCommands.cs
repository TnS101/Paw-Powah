namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Items.Models;
    using Application.Services.Interfaces.Game.Items;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.ManyToMany;
    using Domain.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class ItemCommands : BaseService, IItemCommands
    {
        public ItemCommands(IPawContext context)
            : base(context)
        {
        }

        public async Task Create(ItemInputModel input)
        {
            if (input.Slot == "Weapon")
            {
                this.Context.Weapons.Add(new Weapon
                {
                    Name = input.Name,
                    HealthIncrease = input.HealthIncrease,
                    ManaIncrease = input.ManaIncrease,
                    HealthRegenIncrease = input.HealthRegenIncrease,
                    ManaRegenIncrease = input.ManaRegenIncrease,
                    CritChanceIncrease = input.CritChanceIncrease,
                    MovementSpeedIncrease = input.MovementSpeedIncrease,
                    AttackSpeedIncrease = input.AttackSpeedIncrease,
                    Damage = input.Damage,
                    AttackSpeed = input.AttackSpeed,
                    BuyPrice = input.BuyPrice,
                    SellPrice = input.SellPrice,
                });
            }
            else if (input.Slot == "Amulet")
            {
                this.Context.Amulets.Add(new Amulet
                {
                    Name = input.Name,
                    HealthIncrease = input.HealthIncrease,
                    ManaIncrease = input.ManaIncrease,
                    HealthRegenIncrease = input.HealthRegenIncrease,
                    ManaRegenIncrease = input.ManaRegenIncrease,
                    CritChanceIncrease = input.CritChanceIncrease,
                    MovementSpeedIncrease = input.MovementSpeedIncrease,
                    AttackSpeedIncrease = input.AttackSpeedIncrease,
                    BuffStatType = input.StatRegenType,
                    BuffAmount = input.RegenAmount,
                    BuffDuration = input.BuffDuration,
                    Cooldown = input.Cooldown,
                    BuyPrice = input.BuyPrice,
                    SellPrice = input.SellPrice,
                });
            }
            else if (input.Slot == "Consumeable")
            {
                this.Context.Consumeables.Add(new Consumeable
                {
                    Name = input.Name,
                    Charges = input.Charges,
                    StatRegenType = input.StatRegenType,
                    RegenAmount = input.RegenAmount,
                    BuyPrice = input.BuyPrice,
                    SellPrice = input.SellPrice,
                });
            }
            else
            {
                this.Context.Armors.Add(new Armor
                {
                    Name = input.Name,
                    HealthIncrease = input.HealthIncrease,
                    ManaIncrease = input.ManaIncrease,
                    HealthRegenIncrease = input.HealthRegenIncrease,
                    ManaRegenIncrease = input.ManaRegenIncrease,
                    CritChanceIncrease = input.CritChanceIncrease,
                    MovementSpeedIncrease = input.MovementSpeedIncrease,
                    AttackSpeedIncrease = input.AttackSpeedIncrease,
                    ArmorValue = input.ArmorValue,
                    ResistanceValue = input.ResistanceValue,
                    BuyPrice = input.BuyPrice,
                    SellPrice = input.SellPrice,
                    Slot = input.Slot,
                });
            }

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Delete(string type, int id)
        {
            if (type == "Amulet")
            {
                this.Context.Amulets.Remove(await this.Context.Amulets.FindAsync(id));
            }
            else if (type == "Weapon")
            {
                this.Context.Weapons.Remove(await this.Context.Weapons.FindAsync(id));
            }
            else if (type == "Armor")
            {
                this.Context.Armors.Remove(await this.Context.Armors.FindAsync(id));
            }
            else
            {
                this.Context.Consumeables.Remove(await this.Context.Consumeables.FindAsync(id));
            }

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task Update(string type, int id, ItemInputModel input)
        {
            if (type == "Amulet")
            {
                var amulet = await this.Context.Amulets.FindAsync(id);

                if (!string.IsNullOrWhiteSpace(input.BuffStatType))
                {
                    amulet.BuffStatType = input.BuffStatType;
                }

                if (input.BuffDuration > 0)
                {
                    amulet.BuffDuration = input.BuffDuration;
                }
                
                if (input.Cooldown > 0) 
                {
                    amulet.Cooldown = input.Cooldown;
                }

                this.ItemNullCheck(amulet, input);
                this.EquipableItemNullCheck(amulet, input);
            }
            else if (type == "Armor") 
            {
                var armor = await this.Context.Armors.FindAsync(id);

                if (input.ArmorValue > 0) 
                {
                    armor.ArmorValue = input.ArmorValue;
                }

                if (input.ResistanceValue > 0) 
                {
                    armor.ResistanceValue = input.ResistanceValue;
                }

                this.ItemNullCheck(armor, input);
                this.EquipableItemNullCheck(armor, input);
            }
            else if (type == "Weapon") 
            {
                var weapon = await this.Context.Weapons.FindAsync(id);

                if (input.AttackSpeed > 0)
                {
                    weapon.AttackSpeed = input.AttackSpeed;
                }

                if (input.Damage > 0)
                {
                    weapon.Damage = input.Damage;
                }

                this.ItemNullCheck(weapon, input);
                this.EquipableItemNullCheck(weapon, input);
            }else 
            {
                var consumeable = await this.Context.Consumeables.FindAsync(id);

                if (!string.IsNullOrWhiteSpace(input.StatRegenType))
                {
                    consumeable.StatRegenType = input.StatRegenType;
                }

                if (input.RegenAmount > 0)
                {
                    consumeable.RegenAmount = input.RegenAmount;
                }

                this.ItemNullCheck(consumeable, input);
            }

            await this.Context.SaveChangesAsync(CancellationToken.None);
        }
        
        public async Task Loot(long playerId, string type, int id, int amount)
        {
            var player = await this.Context.Players.FindAsync(playerId);

            if (amount > player.InventoryCapacity)
            {
                amount = player.InventoryCapacity;
                player.InventoryCapacity = 0;
            }
            else
            {
                player.InventoryCapacity -= amount;
            }

            if (type == "Amulet")
            {
                var inventory = await this.Context.PlayersAmulets.FirstOrDefaultAsync(i => i.PlayerId == player.Id && i.AmuletId == id);

                if (inventory == null)
                {
                    this.Context.PlayersAmulets.Add(new PlayerAmulets
                    {
                        PlayerId = player.Id,
                        AmuletId = id,
                        Amount = amount,
                    });
                }
                else 
                {
                    inventory.Amount += amount;
                }
            }else if (type == "Armor") 
            {
                var inventory = await this.Context.PlayersArmors.FirstOrDefaultAsync(i => i.PlayerId == player.Id && i.ArmorId == id);

                if (inventory == null)
                {
                    this.Context.PlayersArmors.Add(new PlayerArmors
                    {
                        PlayerId = player.Id,
                        ArmorId = id,
                        Amount = amount,
                    });
                }
                else
                {
                    inventory.Amount += amount;
                }
            }
            else if (type == "Weapon")
            {
                var inventory = await this.Context.PlayersWeapons.FirstOrDefaultAsync(i => i.PlayerId == player.Id && i.WeaponId == id);

                if (inventory == null)
                {
                    this.Context.PlayersWeapons.Add(new PlayerWeapons
                    {
                        PlayerId = player.Id,
                        WeaponId = id,
                        Amount = amount,
                    });
                }
                else
                {
                    inventory.Amount += amount;
                }
            }
            else
            {
                var inventory = await this.Context.PlayersConsumeables.FirstOrDefaultAsync(i => i.PlayerId == player.Id && i.ConsumeableId == id);

                if (inventory == null)
                {
                    this.Context.PlayersConsumeables.Add(new PlayerConsumeables
                    {
                        PlayerId = player.Id,
                        ConsumeableId = id,
                        Amount = amount,
                    });
                }
                else
                {
                    inventory.Amount += amount;
                }
            }
        }

        private void ItemNullCheck(IItem item, ItemInputModel input)
        {
            if (!string.IsNullOrWhiteSpace(input.Name))
            {
                item.Name = input.Name;
            }

            if (!string.IsNullOrWhiteSpace(input.ImagePath))
            {
                item.ImagePath = input.ImagePath;
            }

            if (item.BuyPrice > 0)
            {
                item.BuyPrice = input.BuyPrice;
            }

            if (item.SellPrice > 0)
            {
                item.SellPrice = input.SellPrice;
            }
        }

        private void EquipableItemNullCheck(IEquipableItem equipableItem, ItemInputModel input)
        {
            if (input.HealthIncrease > 0)
            {
                equipableItem.HealthIncrease = input.HealthIncrease;
            }

            if (input.ManaIncrease > 0)
            {
                equipableItem.ManaIncrease = input.ManaIncrease;
            }

            if (input.HealthRegenIncrease > 0)
            {
                equipableItem.HealthRegenIncrease = input.HealthRegenIncrease;
            }

            if (input.ManaRegenIncrease > 0)
            {
                equipableItem.ManaRegenIncrease = input.ManaRegenIncrease;
            }

            if (input.AttackSpeedIncrease > 0)
            {
                equipableItem.AttackSpeedIncrease = input.AttackSpeedIncrease;
            }

            if (input.CritChanceIncrease > 0)
            {
                equipableItem.CritChanceIncrease = input.CritChanceIncrease;
            }

            if (input.MovementSpeedIncrease > 0)
            {
                equipableItem.MovementSpeedIncrease = input.MovementSpeedIncrease;
            }
        }
    }
}
