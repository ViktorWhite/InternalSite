using InternalSite.Application.Skill.Queries.Common;
using InternalSite.Application.Skill.Queries.GetListSkillsQuery;
using Shouldly;

namespace InternalSiteTests.Skill.Queries
{
    /// <summary>
    /// Тест проверяет запрос всех навыков 
    /// </summary>
    [Collection("QueryCollection")]
    public class GetListSkillQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetListSkillQueryHandler_Success()
        {
            var handler = new GetListSkillQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetListSkillsQuery
                { },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<List<SkillVM>>();
            result.Count.ShouldBe(2);
        }
    }
}
