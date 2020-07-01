namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Game.Items.InputModels;
    using Application.Services.Interfaces.Game.Items;
    using Domain.Entities.Game.Items;
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

        public async Task Update(ItemInputModel input, int id)
        {
        }
    }
}
