using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.CreateSkill.Tests
{
    public class CreateSkillCommandValidatorTests
    {
        private readonly CreateSkillCommandValidator _validator;

        public CreateSkillCommandValidatorTests()
        {
            _validator = new CreateSkillCommandValidator();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new CreateSkillCommand
            {
                Name = string.Empty
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(csc => csc.Name);
        }

        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new CreateSkillCommand
            {
                Name = new string('A', 51)
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(csc => csc.Name);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new CreateSkillCommand
            {
                Name = "Valid Skill"
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
