namespace Application.Common.Service_Helpers
{
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;

    public abstract class BaseService
    {
        public BaseService(IPawContext context)
        {
            this.Context = context;
        }

        protected IPawContext Context { get; }
    }
}
