namespace WalletService.Domain.DTOs;

public class EntryDTO
{
    public decimal Amount { get; set; }
    public EntryType EntryType { get; set; }
}