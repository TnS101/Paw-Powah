namespace Application.Common.Service_Helpers
{
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class MapService<Full, Min> where Full : class where Min : class
    {
        public MapService(IMapper mapper, IPawContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        protected IMapper Mapper { get; }

        protected IPawContext Context { get; }

        protected Full MapInfo(object source) 
        {
            return this.Mapper.Map<Full>(source);
        }

        protected async Task<IEnumerable<Min>> MapCollection(IQueryable collection) 
        {
            return await collection.ProjectTo<Min>(this.Mapper.ConfigurationProvider).ToArrayAsync();
        }
    }
}
