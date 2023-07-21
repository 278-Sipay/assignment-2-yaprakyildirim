using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SipayApi.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SipayApi.Data.Domain;

[Table("Transaction", Schema = "dbo")]
public class Transaction : IdBaseModel
{
    public int AccountNumber { get; set; }
    public virtual Account Account { get; set; }
    public decimal CreditAmount { get; set; }   // -
    public decimal DebitAmount { get; set; }    // +
    public string Description { get; set; }
    public DateTime TransactionDate { get; set; }
    public string ReferenceNumber { get; set; }
}


public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasIndex(x => x.AccountNumber);
        builder.HasIndex(x => x.ReferenceNumber);
    }

}
