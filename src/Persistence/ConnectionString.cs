namespace Persistence
{
    using Application.Common.Interfaces;

    public class ConnectionString : IConnectionString
    {
        public string DefaultPath => @"Server=.;Database=PawPowah;Integrated Security=True;MultipleActiveResultSets=true;";

        public string VolatilePath => @"Server=.;Database=PawPowah-Volatile;Integrated Security=True;MultipleActiveResultSets=true;";
    }
}
