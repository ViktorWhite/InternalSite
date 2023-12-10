using InternalSite.Application.Category.Commands.CreateCategory;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Category.Commands
{
    /// <summary>
    /// Тест проверяет команду создания структурного подразделения
    /// </summary>
    public class CreateCategoryCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCategoryCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreateCategoryCommandHandler(Context);
            var nameCategory = "Тестовое имя";

            // Act
            var categoryId = await handler.Handle(
                new CreateCategoryCommand
                {
                   Name = nameCategory
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Categories.SingleOrDefaultAsync(category =>
                category.Id == categoryId && 
                category.Name == nameCategory));
        }
    }
}
