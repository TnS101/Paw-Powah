namespace Application.Common.Interfaces
{
    public interface IConnectionString
    {
          string DefaultPath { get; }

          string VolatilePath { get; }
    }
}
