namespace Persistence
{
    using Application.Common.Interfaces;

    public class ConnectionString : IConnectionString
    {
        public string PawPath => "Server=.;Database=PawPowah;Trusted_Connection=True;MultipleActiveResultSets=true;";
       
        public string VolatilePath => "Server=.;Database=PawPowah-Volatile;Trusted_Connection=True;MultipleActiveResultSets=true;";
    }
}
