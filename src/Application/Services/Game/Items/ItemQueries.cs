namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Items;
    using AutoMapper;

    public class AdminItemQueries : MapService, IItemQueries
    {
        public AdminItemQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }
    }
}
