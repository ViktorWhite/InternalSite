using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Person.Commands.DeletePerson;

namespace InternalSiteTests.Person.Commands
{
    /// <summary>
    /// Тесты проверяют команду удаления сотрудника
    /// </summary>
    public class DeletePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeletePersonCommandHandler_Success()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            // Act
            await handler.Handle(new DeletePersonCommand
            {
                Id = 1,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Persons.SingleOrDefault(p => p.Id == 1));
        }

        [Fact]
        public async Task DeletePersonCommandHandler__FailOnWrongId()
        {
            // Arrange
            var handler = new DeletePersonCommandHandler(Context);

            //Act
            // Assert 
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeletePersonCommand
                {
                   Id = 10
                }, CancellationToken.None));
        }
    }
}
