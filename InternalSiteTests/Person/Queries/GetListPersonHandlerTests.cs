using InternalSite.Application.Person.Queries.GetListPersonQuery;
using Shouldly;
using InternalSite.Application.Person.Queries.Common;

namespace InternalSiteTests.Person.Queries
{
    /// <summary>
    /// Тест проверяет запрос всех сотрудников с их навыками
    /// </summary>
    public class GetListPersonHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetListPersonQueryHandler_Success()
        {
            var handler = new GetListPersonQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetListPersonQuery
                { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<PersonVM>>();
            result.Count.ShouldBe(2);
        }
    }
}
