using SipayApi.Base;
using System.Linq.Expressions;

namespace SipayApi.Data.Repository;

/// Genel bir depo sınıfıdır. Temel CRUD işlevselliği sağlamak için bir veritabanı bağlamı üzerinde çalışır.
/// BaseModel'den türetilen varlıklar için kullanılır.
public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : BaseModel
{
    private readonly SimDbContext dbContext;
    public GenericRepository(SimDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// Belirli bir ifadeye göre varlıkları getirir.
    public IEnumerable<Entity> GetByParameter(Expression<Func<Entity, bool>> expression)
    {
        return dbContext.Set<Entity>().Where(expression).ToList();
    }
}