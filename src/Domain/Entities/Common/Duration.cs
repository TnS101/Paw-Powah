namespace Domain.Entities.Common
{
    using System;

    public class Duration
    {
        public long Id { get; set; }

        public long UnitId { get; set; }

        public DateTime EndsOn { get; set; }

        public string EffectType { get; set; }

        public double EffectPower { get; set; }
    }
}
