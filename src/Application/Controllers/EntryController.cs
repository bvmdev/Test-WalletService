using MediatR;
using Microsoft.AspNetCore.Mvc;
using WalletService.Application.Commands;
using WalletService.Domain;
using WalletService.Domain.DTOs;

namespace WalletService.Presentation;

[ApiController]
[Route("api/[controller]")]
public class EntryController : ControllerBase
{
    private readonly IMediator _mediator;

    public EntryController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEntryAsync([FromBody] EntryDTO entry)
    {
        var command = new AddEntryCommand(entry.Amount, entry.EntryType);
        await _mediator.Send(command);
        return Ok();
    }
}