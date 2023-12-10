using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.DeleteSkill.Tests
{
    public class DeleteSkillCommandValidatorTests
    {
        private readonly DeleteSkillCommandValidator _validator;

        public DeleteSkillCommandValidatorTests()
        {
            _validator = new DeleteSkillCommandValidator();
        }

        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new DeleteSkillCommand
            {
                Id = 0
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(dsc => dsc.Id);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new DeleteSkillCommand
            {
                Id = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
