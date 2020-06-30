namespace Application.Services.Common.Identity
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Common.Users.ViewModels;
    using Application.Services.Interfaces.Identity;
    using AutoMapper;
    using System.Threading.Tasks;

    public class UserQueries : MapService, IUserQueries
    {
        public UserQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<UserMinViewModel> GetUserPanel(string id)
        {
            return null;
        }
    }
}
