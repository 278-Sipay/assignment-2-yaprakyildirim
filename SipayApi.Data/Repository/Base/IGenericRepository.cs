using System.Linq.Expressions;

namespace SipayApi.Data.Repository;

public interface IGenericRepository<Entity> where Entity : class
{
    ///expression Varlıkları filtrelemek için kullanılacak lambda ifadesi. 
    IEnumerable<Entity> GetByParameter(Expression<Func<Entity, bool>> expression);
}