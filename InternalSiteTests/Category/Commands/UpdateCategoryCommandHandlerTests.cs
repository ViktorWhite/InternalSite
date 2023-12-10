using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Category.Commands.UpdateCategory;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Category.Commands
{
    /// <summary>
    /// Тест проверяет команду изменения структурного подразделения
    /// </summary>
    public class UpdateCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateCategoryCommandHandler_Success()
        {
            // Arrange 
            var handler = new UpdateCategoryCommandHandler(Context);
            var updatedName = "Test name category";

            // Act
            await handler.Handle(new UpdateCategoryCommand
            {
                Id = 1,
                Name = updatedName,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Categories.SingleOrDefaultAsync(c => 
            c.Id == 1 && 
            c.Name == updatedName));
        }

        [Fact]
        public async Task UpdateCategoryCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateCategoryCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateCategoryCommand
                {
                    Id = 10,
                    Name = "тестовое имя",
                }, CancellationToken.None));
        }
    }
}
