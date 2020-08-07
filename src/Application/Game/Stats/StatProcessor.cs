namespace Application.Game.Stats
{
    using Domain.Interfaces;

    public class StatProcessor
    {
        public void Execute(IUnit unit, string statType, double power, string mathOperation)
        {
            switch (statType)
            {
                case "MaxHP": unit.MaxHP = this.OperationResult(unit.MaxHP, mathOperation, power * unit.MaxHP); break;

                case "MaxMana": unit.MaxMana = this.OperationResult(unit.MaxMana, mathOperation, power * unit.MaxMana); break;

                case "CurrentHP": unit.CurrentHP = this.OperationResult(unit.CurrentHP, mathOperation, power * unit.CurrentHP); break;

                case "CurrentMana": unit.CurrentMana = this.OperationResult(unit.CurrentMana, mathOperation, power * unit.CurrentMana); break;

                case "AttackPower": unit.AttackPower = this.OperationResult(unit.AttackPower, mathOperation, power * unit.AttackPower); break;

                case "MagicPower": unit.MagicPower = this.OperationResult(unit.MagicPower, mathOperation, power * unit.MagicPower); break;

                case "HealthRegen": unit.HealthRegen = this.OperationResult(unit.HealthRegen, mathOperation, power * unit.HealthRegen); break;

                case "ManaRegen": unit.ManaRegen = this.OperationResult(unit.ManaRegen, mathOperation, power * unit.ManaRegen); break;

                case "Armor": unit.Armor += this.OperationResult(unit.Armor, mathOperation, power * unit.Armor); break;

                case "Resistance": unit.Resistance = this.OperationResult(unit.Resistance, mathOperation, power * unit.Resistance); break;

                case "CritChance": unit.CritChance = this.OperationResult(unit.CritChance, mathOperation, power * unit.CritChance); break;

                case "AttackSpeed": unit.AttackSpeed = this.OperationResult(unit.AttackSpeed, mathOperation, power * unit.AttackSpeed); break;

                case "MovementSpeed": unit.MovementSpeed = this.OperationResult(unit.MovementSpeed, mathOperation, power * unit.MovementSpeed); break;

                case "Tenacity": unit.Tenacity = this.OperationResult(unit.Tenacity, mathOperation, power * unit.Tenacity); break;
            }
        }

        private double OperationResult(double left, string mathOperation, double right)
        {
            return mathOperation switch
            {
                "+" => left + right,
                "-" => left - right,
                _ => left,
            };
        }
    }
}
