using MediatR;
using WalletService.Domain;

namespace WalletService.Application.Commands;   

public class AddEntryCommand : IRequest
{
    
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public EntryType EntryType { get; private set; }

        public AddEntryCommand(decimal amount, EntryType entryType)
        {
            Amount = amount;
            CreatedAt = DateTime.Now;
            EntryType = entryType;
        }
    
}