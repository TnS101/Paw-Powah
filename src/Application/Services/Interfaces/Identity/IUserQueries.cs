namespace Application.Services.Interfaces.Identity
{
    using Application.Services.Common.Users.ViewModels;
    using System.Threading.Tasks;

    public interface IUserQueries
    {
        Task<UserMinViewModel> GetUserPanel(string id);
    }
}
