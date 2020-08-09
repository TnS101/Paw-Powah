namespace Application.Common.Query_Helpers
{
    using System.Linq;

    public class QuerySorter<Entity> where Entity : class
    {
        public IQueryable<Entity> Execute(IQueryable<Entity> collection, string criteria, string condition, double value) 
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
