namespace Persistence
{
    using Application.Common.Interfaces;

    public class ConnectionString : IConnectionString
    {
        public string Path => @"Server=.;Database=PawPowah;Integrated Security=True;MultipleActiveResultSets=true;";
    }
}
