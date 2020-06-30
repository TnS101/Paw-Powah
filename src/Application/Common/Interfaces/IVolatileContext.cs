namespace Application.Common.Interfaces
{
    using Domain.Entities.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IVolatileContext
    {
        DbSet<Cooldown> Cooldowns { get; set; }

        DbSet<Duration> Durations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
