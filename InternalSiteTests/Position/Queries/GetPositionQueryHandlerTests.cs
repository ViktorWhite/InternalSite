using InternalSite.Application.Position.Queries.Common;
using InternalSite.Application.Position.Queries.GetPosition;
using Shouldly;

namespace InternalSiteTests.Position.Queries
{
    /// <summary>
    /// Тест проверяет команду запроса должности по ее идентификатору
    /// </summary>
    public class GetPositionQueryHandlerTests : TestCommandBase
    {
        [Collection("QueryCollection")]
        public class GetCategoryQueryHandlerTests : TestCommandBase
        {
            [Fact]
            public async Task GetPositionQueryHandler_Success()
            {
                // Arrange
                var handler = new GetPositionQueryHandler(Context);

                // Act
                var result = await handler.Handle(
                    new GetPositionQuery
                    {
                        Id = 1,
                    },  CancellationToken.None);

                //Assert
                result.ShouldBeOfType<PositionVM>();
                result.Name.ShouldBe("Инженер");
            }
        }
    }
}
