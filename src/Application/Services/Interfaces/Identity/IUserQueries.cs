namespace Application.Services.Interfaces.Identity
{
    using Application.Services.Common.Users.ViewModels;
    using Domain.Identity;
    using System.Threading.Tasks;

    public interface IUserQueries : IQuery<AppUser, UserMinViewModel>
    {
    }
}
