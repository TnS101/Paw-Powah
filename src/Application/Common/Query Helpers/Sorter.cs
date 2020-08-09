namespace Application.Common.Query_Helpers
{
    using System.Linq;

    public class Sorter<T> where T : class
    {
        public IQueryable<T> Execute(IQueryable<T> collection, string criteria, string condition, double value) 
        {
            var property = collection.FirstOrDefault().GetType().GetProperty(criteria);
            return condition switch
            {
                ">" => collection.Where(e => (double)e.GetType().GetProperty(criteria).GetValue(e, null) > value),
                "<" => collection.Where(e => (double)e.GetType().GetProperty(criteria).GetValue(e, null) < value),
                "=" => collection.Where(e => (double)e.GetType().GetProperty(criteria).GetValue(e, null) == value),
                _ => collection,
            };
        }
    }
}
