using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SipayApi.Base;
using SipayApi.Data.Domain;
using SipayApi.Data.Repository;
using SipayApi.Schema;

namespace SipayApi.Service;

[ApiController]
[Route("sipy/api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionRepository repository;
    private readonly IMapper mapper;
    public TransactionController(ITransactionRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    /// Birden fazla sorgu parametresine göre işlemleri filtreleyerek getirir.
    /// Parametreler opsiyoneldir; belirtilen parametrelerle filtreleme yapılır.
    [HttpGet("GetByParameter")]
    public ApiResponse<List<TransactionResponse>> GetByParameter([FromQuery] int? accountNumber, [FromQuery] decimal? minAmountCredit, [FromQuery] decimal? maxAmountCredit, [FromQuery] decimal? minAmountDebit, [FromQuery] decimal? maxAmountDebit, [FromQuery] string? description, [FromQuery] DateTime? beginDate, [FromQuery] DateTime? endDate, [FromQuery] string? referenceNumber)
    {
        var entityList = repository.GetByParameter(x =>
     (!accountNumber.HasValue || x.AccountNumber == accountNumber) &&
     (!minAmountCredit.HasValue || x.CreditAmount >= minAmountCredit) &&
     (!maxAmountCredit.HasValue || x.CreditAmount <= maxAmountCredit) &&
     (!minAmountDebit.HasValue || x.DebitAmount >= minAmountDebit) &&
     (!maxAmountDebit.HasValue || x.DebitAmount <= maxAmountDebit) &&
     (string.IsNullOrEmpty(description) || x.Description.Contains(description)) &&
     (!beginDate.HasValue || x.TransactionDate >= beginDate) &&
     (!endDate.HasValue || x.TransactionDate <= endDate) &&
     (string.IsNullOrEmpty(referenceNumber) || x.ReferenceNumber == referenceNumber)).ToList();

        var mapped = mapper.Map<List<Transaction>, List<TransactionResponse>>(entityList);
        return new ApiResponse<List<TransactionResponse>>(mapped);
    }
}
