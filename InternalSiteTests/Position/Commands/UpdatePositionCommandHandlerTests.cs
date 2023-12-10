using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Position.Commands.UpdatePosition;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Position.Commands
{
    /// <summary>
    /// Тесты проверяют команду изменения должности
    /// </summary>
    public class UpdatePositionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePositionCommandHandler_Success()
        {
            // Arrange 
            var handler = new UpdatePositionCommandHandler(Context);
            var updatedName = "Test name position";

            // Act
            await handler.Handle(new UpdatePositionCommand
            {
                Id = 1,
                Name = updatedName,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Positions.SingleOrDefaultAsync(c => 
            c.Id == 1 && 
            c.Name == updatedName));
        }

        [Fact]
        public async Task UpdatePositionCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePositionCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePositionCommand
                {
                    Id = 10,
                    Name = "тестовое имя",
                }, CancellationToken.None));
        }
    }
}
