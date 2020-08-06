namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Items.Models;
    using Application.Services.Interfaces.Game.Items;
    using Domain.Entities.Game.Items;
    using Domain.Interfaces;
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
                    BuffStatType = input.StatType,
                    BuffAmount = input.StatAmount,
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
                    StatRegenType = input.StatType,
                    RegenAmount = input.StatAmount,
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
            IItem item;

            if (type == "Amulet")
            {
                item = await this.Context.Amulets.FindAsync(id);

                this.EquipableItemNullCheck((IEquipableItem)item, input);
            }
            else if (type == "Armor") 
            {
                item = await this.Context.Armors.FindAsync(id);

                this.EquipableItemNullCheck((IEquipableItem)item, input);
            }
            else if (type == "Weapon") 
            {
                item = await this.Context.Weapons.FindAsync(id);

                this.EquipableItemNullCheck((IEquipableItem)item, input);
            }else 
            {
                item = await this.Context.Amulets.FindAsync(id);
            }

            this.ItemNullCheck(item, input);

            await this.Context.SaveChangesAsync(CancellationToken.None);
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
