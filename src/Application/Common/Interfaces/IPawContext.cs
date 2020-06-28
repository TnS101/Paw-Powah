namespace Application.Common.Interfaces
{
    using Domain.Identity;
    using Microsoft.EntityFrameworkCore;

    public interface IPawContext
    {
        DbSet<AppUser> Users { get; set; }
    }
}
