using InternalSite.Application.Category.Queries.Common;
using InternalSite.Application.Category.Queries.GetCategoryQuery;
using Shouldly;

namespace InternalSiteTests.Category.Queries
{
    /// <summary>
    /// Тест проверяет запрос структурного подразделения по его идентификатору
    /// </summary>
    [Collection("QueryCollection")]
    public class GetCategoryQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetCategoryQueryHandler_Success()  
        {
            // Arrange
            var handler = new GetCategoryQueryHandler(Context);
            
            // Act
            var result = await handler.Handle(
                new GetCategoryQuery
                {
                   Id = 1,
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<CategoryVM>();
            result.Name.ShouldBe("АСУТП");
        }
    }
}
