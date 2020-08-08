namespace Application.Services.Game.Players.Models
{
    public class PlayerFullViewModel
    {
        public long Id { get; set; }

        public string KindName { get; set; }

        public string ClassName { get; set; }

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

        public int Gold { get; set; }

        public double XP { get; set; }

        public double XPCap { get; set; }

        public double Armor { get; set; }

        public double Resistance { get; set; }
    }
}
