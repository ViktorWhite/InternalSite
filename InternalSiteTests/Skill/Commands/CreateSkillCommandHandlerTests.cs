using InternalSite.Application.Skill.Commands.CreateSkill;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Skill.Commands
{
    /// <summary>
    /// Тест проверяет команду создания навыка сотрудника
    /// </summary>
    public class CreateSkillCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateSkillCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreateSkillCommandHandler(Context);
            var nameNewSkill = "Тестовое скилл";

            // Act
            var idNewSkill = await handler.Handle(
                new CreateSkillCommand
                {
                   Name = nameNewSkill
                }, CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Skills.SingleOrDefaultAsync(s =>
                s.Id == idNewSkill && 
                s.Name == nameNewSkill));
        }
    }
}
