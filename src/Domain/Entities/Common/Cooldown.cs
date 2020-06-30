namespace Domain.Entities.Common
{
    using System;

    public class Cooldown
    {
        public long Id { get; set; }

        public long UnitId { get; set; }

        public int SpellId { get; set; }

        public DateTime EndsOn { get; set; }
    }
}
