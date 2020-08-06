namespace Application.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuery<T> where T : class
    {
        Task<T> GetInfo(long id);

        Task<IEnumerable<T>> GetAll();
    }
}
