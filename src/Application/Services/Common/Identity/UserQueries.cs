namespace Application.Services.Common.Identity
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Common.Users.ViewModels;
    using Application.Services.Interfaces.Identity;
    using AutoMapper;
    using Domain.Identity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UserQueries : MapService<AppUser,UserMinViewModel>, IUserQueries
    {
        public UserQueries(IMapper mapper, IPawContext context)
            : base(mapper, context)
        {
        }

        public async Task<IEnumerable<UserMinViewModel>> GetAll()
        {
            return await this.MapCollection(this.Context.Users);
        }

        public async Task<AppUser> GetInfo(long id)
        {
            return await this.Context.Users.FindAsync(id);
        }
    }
}
