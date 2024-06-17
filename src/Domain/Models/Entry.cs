using Microsoft.AspNetCore.Authentication;

namespace WalletService.Domain;

public class Entry
{
    public int Id { get; set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public EntryType EntryType { get; private set; }
    
    public Entry(decimal Amount, DateTime createdAt, EntryType EntryType)
    {
        
        this.Amount = (EntryType == EntryType.Credit) ? Amount : Amount * -1;
        this.CreatedAt = DateTime.Now;
        this.EntryType = EntryType;
    }
}