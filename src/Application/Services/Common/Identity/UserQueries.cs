namespace Application.Services.Common.Identity
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Common.Users.ViewModels;
    using Application.Services.Interfaces.Identity;
    using System.Threading.Tasks;

    public class UserQueries : BaseService, IUserQueries
    {
        public UserQueries(IPawContext context)
            :base(context)
        {
        }

        public async Task<UserMinViewModel> GetUserPanel(string id)
        {
            return null;
        }
    }
}
