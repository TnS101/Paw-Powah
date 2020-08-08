namespace Application.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuery<Full, Min> where Full : class where Min : class
    {
        Task<Full> GetInfo(long id);

        Task<IEnumerable<Min>> GetAll();
    }
}
