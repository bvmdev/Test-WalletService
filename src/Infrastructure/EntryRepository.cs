using WalletService.Domain;
using WalletService.Domain.Interfaces;

namespace WalletService.Infrastructure;

public class EntryRepository : IEntryRepository
{
    private readonly ApplicationDbContext _context;
    
    public EntryRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Entry> AddEntryAsync(Entry entry)
    {
        _context.Entries.Add(entry);
        var newEntry = await _context.SaveChangesAsync();
        return entry;
    }
}