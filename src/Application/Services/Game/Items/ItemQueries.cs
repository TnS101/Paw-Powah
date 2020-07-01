namespace Application.Services.Game.Items
{
    using Application.Common.Interfaces;
    using Application.Common.Service_Helpers;
    using Application.Services.Interfaces.Game.Items;
    using AutoMapper;

    public class ItemQueries : MapService, IItemQueries
    {
        public ItemQueries(IMapper mapper, IPawContext context)
            :base(mapper, context)
        {
        }
    }
}
