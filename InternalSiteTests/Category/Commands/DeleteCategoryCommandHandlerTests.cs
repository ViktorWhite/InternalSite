using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Category.Commands.DeleteCategory;

namespace InternalSiteTests.Category.Commands
{
    /// <summary>
    /// Тесты проверяют команду удаления структурного подразделения
    /// </summary>
    public class DeleteCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCategoryCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteCategoryCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteCategoryCommand
            {
               Id = 1,
            }, CancellationToken.None);
            
            // Assert
            Assert.Null(Context.Categories.SingleOrDefault(Category => 
            Category.Id == 1));

        }

        [Fact]
        public async Task DeleteCategoryCommandHandler__FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteCategoryCommandHandler(Context);

            //Act
            // Assert 
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteCategoryCommand
                {
                    Id = 10
                }, CancellationToken.None));
        }
    }
}
