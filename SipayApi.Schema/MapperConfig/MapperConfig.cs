using AutoMapper;
using SipayApi.Data.Domain;

namespace SipayApi.Schema;

public class MapperConfig : Profile
{
    /// AutoMapper profil sınıfı. TransactionRequest'den Transaction'a 
    /// ve Transaction'dan TransactionResponse'a dönüşüm haritalarını tanımlar.
    public MapperConfig()
    {
        CreateMap<TransactionRequest, Transaction>();
        CreateMap<Transaction, TransactionResponse>();
    }
}
