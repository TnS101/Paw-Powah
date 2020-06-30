namespace Domain.Interfaces
{
    public interface IUnit
    {
        long Id { get; set; }

        string Name { get; set; }

        int Level { get; set; }

        double MaxHP { get; set; }

        double CurrentHP { get; set; }

        double MaxMana { get; set; }

        double CurrentMana { get; set; }

        double AttackPower { get; set; }

        double MagicPower { get; set; }

        double HealthRegen { get; set; }

        double ManaRegen { get; set; }

        double Armor { get; set; }

        double Resistance { get; set; }

        double CritChance { get; set; }

        double AttackSpeed { get; set; }

        double MovementSpeed { get; set; }

        double Tenacity { get; set; }

        bool IsStunned { get; set; }

        bool IsSilenced { get; set; }

        bool IsRooted { get; set; }

        bool IsConfused { get; set; }

        bool IsFeared { get; set; }

        int Gold { get; set; }

        string ImagePath { get; set; }
    }
}
