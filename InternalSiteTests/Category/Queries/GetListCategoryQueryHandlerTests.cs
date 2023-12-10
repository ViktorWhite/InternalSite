using InternalSite.Application.Category.Queries.Common;
using InternalSite.Application.Category.Queries.GetCategoriesQuery;
using Shouldly;

namespace InternalSiteTests.Category.Queries
{
    /// <summary>
    /// Тест проверяет запрос всех структурных подразделений
    /// </summary>
    [Collection("QueryCollection")]
    public class GetListCategoryQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetCategoryListQueryHandler_Success()
        {
            var handler = new GetListCategoryQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetListCategoryQuery
                {},
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<CategoryVM>>();
            result.Count.ShouldBe(2);
        }
    }
}
