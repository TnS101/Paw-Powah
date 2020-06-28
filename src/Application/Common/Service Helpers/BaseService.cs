namespace Application.Common.Service_Helpers
{
    using Application.Common.Interfaces;

    public abstract class BaseService
    {
        public BaseService(IPawContext context)
        {
            this.Context = context;
        }

        protected IPawContext Context { get; }
    }
}
