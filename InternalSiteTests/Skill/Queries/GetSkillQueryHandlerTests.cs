using InternalSite.Application.Skill.Queries.Common;
using InternalSite.Application.Skill.Queries.GetSkillQuery;
using Shouldly;

namespace InternalSiteTests.Skill.Queries
{
    [Collection("QueryCollection")]
    public class GetSkillQueryHandlerTests : TestCommandBase
    {
        /// <summary>
        /// Тест проверяет запрос всех навыка
        /// </summary>
        [Fact]
        public async Task GetSkillQueryHandler_Success()
        {
            // Arrange
            var handler = new GetSkillQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetSkillQuery
                {
                    Id = 1,
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<SkillVM>();
            result.Name.ShouldBe("Усидчивость");
        }
    }
}
