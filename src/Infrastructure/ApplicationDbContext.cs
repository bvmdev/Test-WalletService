using Microsoft.EntityFrameworkCore;
using WalletService.Domain;

namespace WalletService.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Entry> Entries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
}