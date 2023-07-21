using SipayApi.Data.Domain;

namespace SipayApi.Data.Repository;

/// Transaction nesneleri için özelleştirilmiş depo sınıfıdır. 
/// GenericRepository'den türetilmiştir ve ITransactionRepository arabirimini uygular.
public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
{
    private readonly SimDbContext dbContext;
    public TransactionRepository(SimDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    /// Belirli bir referans numarasına göre işlemleri getirir. Referans numarasıyla eşleşen işlemlerin listesi.
    public List<Transaction> GetByReference(string reference)
    {
        return dbContext.Set<Transaction>().Where(x => x.ReferenceNumber == reference).ToList();
    }
}
