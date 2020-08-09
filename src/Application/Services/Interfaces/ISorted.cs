namespace Application.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISorted<Min> where Min : class
    {
        Task<IEnumerable<Min>> GetSorted(string criteria, string condition, double value);
    }
}
