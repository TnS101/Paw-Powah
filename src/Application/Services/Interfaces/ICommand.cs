namespace Application.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICommand<T> where T : class
    {
        Task Create(T input);

        Task Update(long id, T input);

        Task Delete(long id);
    }
}
