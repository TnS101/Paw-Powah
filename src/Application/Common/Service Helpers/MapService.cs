namespace Application.Common.Service_Helpers
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using Domain.Entities.Game.Units;

    public abstract class MapService
    {
        public MapService(IMapper mapper, IPawContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        protected IMapper Mapper { get; }

        protected IPawContext Context { get; }
    }
}
