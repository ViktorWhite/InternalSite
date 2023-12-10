using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Skill.Commands.DeleteSkill;

namespace InternalSiteTests.Skill.Commands
{
    /// <summary>
    /// Тесты проверяют команду удаления навыка сотрудника
    /// </summary>
    public class DeleteSkillCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteSkillCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteSkillCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteSkillCommand
            {
                Id = 1,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Skills.SingleOrDefault(s => 
            s.Id == 1));
        }

        [Fact]
        public async Task DeleteCategoryCommandHandler__FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteSkillCommandHandler(Context);

            //Act
            // Assert 
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteSkillCommand
                {
                    Id = 10
                }, CancellationToken.None));
        }
    }
}
