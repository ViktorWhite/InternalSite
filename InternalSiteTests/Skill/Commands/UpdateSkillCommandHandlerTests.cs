using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Skill.Commands.UpdateSkill;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Skill.Commands
{
    /// <summary>
    /// Тесты проверяют команду изменения навыка сотрудника
    /// </summary>
    public class UpdateSkillCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateSkillCommandHandler_Success()
        {
            // Arrange 
            var handler = new UpdateSkillCommandHandler(Context);
            var updatedName = "Test name skill";

            // Act
            await handler.Handle(new UpdateSkillCommand
            {
                Id = 1,
                Name = updatedName,
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Skills.SingleOrDefaultAsync(s => 
            s.Id == 1 && 
            s.Name == updatedName));
        }

        [Fact]
        public async Task UpdateSkillCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateSkillCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateSkillCommand
                {
                    Id = 10,
                    Name = "тестовое имя",
                }, CancellationToken.None));
        }
    }
}
