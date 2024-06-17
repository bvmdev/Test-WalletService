using MediatR;
using WalletService.Application.Commands;
using WalletService.Domain;
using WalletService.Domain.Interfaces;

namespace WalletService.Application.Services;

public class AddEntryHandler : IRequestHandler<AddEntryCommand>
{
    private readonly IEntryRepository _entryRepository;

    public AddEntryHandler(IEntryRepository entryRepository)
    {
        _entryRepository = entryRepository;
    }

    public async Task Handle(AddEntryCommand command, CancellationToken cancellationToken)
    {
        if (command.Amount == 0)
        {
            throw new ArgumentException("Invalid Amount", nameof(command.Amount));
        }
        
        var entry = new Entry(command.Amount, command.CreatedAt,command.EntryType);                
        await _entryRepository.AddEntryAsync(entry);
    }
}