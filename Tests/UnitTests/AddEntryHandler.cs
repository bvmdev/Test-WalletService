using Moq;
using WalletService.Application.Commands;
using WalletService.Application.Services;
using WalletService.Domain;
using WalletService.Domain.Interfaces;

public class AddEntryHandlerTests
{
    private readonly Mock<IEntryRepository> _mockEntryRepository;
    private readonly AddEntryHandler _handler;

    public AddEntryHandlerTests()
    {
        _mockEntryRepository = new Mock<IEntryRepository>();
        _handler = new AddEntryHandler(_mockEntryRepository.Object);
    }

    [Fact]
    public async Task Handle_AddEntrySuccessfully()
    {
        // Arrange
        var command = new AddEntryCommand(100,EntryType.Credit);

        // Act
        await _handler.Handle(command, default);

        // Assert
        _mockEntryRepository.Verify(x => x.AddEntryAsync(It.Is<Entry>(e => e.Amount == command.Amount && e.EntryType == command.EntryType)), Times.Once);
    }

    [Fact]
    public async Task Handle_ThrowsExceptionWhenAmountIsZero()
    {
        // Arrange
        var command = new AddEntryCommand(0,EntryType.Credit);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, default));
    }
    
    [Fact]
    public async Task Handle_Debit_AddEntrySuccessfully()
    {
        // Arrange
        var command = new AddEntryCommand(100,EntryType.Debit);

        // Act
        await _handler.Handle(command, default);

        // Assert
        _mockEntryRepository.Verify(x => x.AddEntryAsync(It.Is<Entry>(e => e.Amount * -1 == command.Amount && e.EntryType == command.EntryType)), Times.Once);
    }

    [Fact]
    public async Task Handle_Debit_ThrowsExceptionWhenAmountIsZero()
    {
        // Arrange
        var command = new AddEntryCommand(0,EntryType.Debit);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, default));
    }
    
}