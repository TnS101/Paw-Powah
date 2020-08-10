namespace Application.Common.Service_Helpers
{
    using Application.Common.Interfaces;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class BaseService
    {
        public BaseService(IPawContext context)
        {
            this.Context = context;
        }

        protected IPawContext Context { get; }

        protected async Task SaveAsync() 
        {
            await this.SaveAsync();
        }
    }
}
