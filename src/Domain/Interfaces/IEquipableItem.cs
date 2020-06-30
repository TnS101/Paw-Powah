namespace Domain.Interfaces
{
    public interface IEquipableItem
    {
        double HealthIncrease { get; set; }

        double ManaIncrease { get; set; }

        double HealthRegenIncrease { get; set; }

        double ManaRegenIncrease { get; set; }

        double CritChanceIncrease { get; set; }

        double MovementSpeedIncrease { get; set; }

        double AttackSpeedIncrease { get; set; }
    }
}
