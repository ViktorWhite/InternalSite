using InternalSite.Application.Position.Commands.CreatePosition;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Position.Commands
{
    /// <summary>
    /// Тест проверяет команду создания должности
    /// </summary>
    public class CreatePositionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePositionCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreatePositionCommandHandler(Context);
            var nameNewPosition = "Тестовое имя";

            // Act
            var idNewPosition = await handler.Handle(
                new CreatePositionCommand
                {
                   Name = nameNewPosition
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Positions.SingleOrDefaultAsync(p =>
                p.Id == idNewPosition && 
                p.Name == nameNewPosition));
        }
    }
}
