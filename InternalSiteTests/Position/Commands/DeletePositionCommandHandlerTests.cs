using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Position.Commands.DeletePosition;

namespace InternalSiteTests.Position.Commands
{
    /// <summary>
    /// Тесты проверяют команду удаления должности
    /// </summary>
    public class DeletePositionCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePositionCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePositionCommandHandler(Context);

            // Act
            await handler.Handle(new DeletePositionCommand
            {
               Id = 1,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Positions.SingleOrDefault(p => 
            p.Id == 1));
        }

        [Fact]
        public async Task DeletePositionCommandHandler__FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePositionCommandHandler(Context);

            //Act
            // Assert 
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePositionCommand
                {
                    Id = 10
                }, CancellationToken.None));
        }
    }
}
