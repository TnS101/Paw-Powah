namespace Application.Services.Common.Identity
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Identity;

    public class UserCommands : BaseService, IUserCommands
    {
        public UserCommands(IPawContext context)
            :base(context)
        {

        }
    }
}
