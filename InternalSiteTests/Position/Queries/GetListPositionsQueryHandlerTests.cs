using InternalSite.Application.Position.Queries.Common;
using InternalSite.Application.Position.Queries.GetPositions;
using Shouldly;

namespace InternalSiteTests.Position.Queries
{
    /// <summary>
    /// Тест проверяет запрос всех должностей
    /// </summary>
    public class GetListPositionsQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetPositionListQueryHandler_Success()
        {
            var handler = new GetListPositionQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetListPositionQuery
                { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<PositionVM>>();
            result.Count.ShouldBe(2);
        }
    }
}
