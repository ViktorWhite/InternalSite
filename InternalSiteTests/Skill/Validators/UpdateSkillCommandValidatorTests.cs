using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.UpdateSkill.Tests
{
    public class UpdateSkillCommandValidatorTests
    {
        private readonly UpdateSkillCommandValidator _validator;

        public UpdateSkillCommandValidatorTests()
        {
            _validator = new UpdateSkillCommandValidator();
        }

        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdateSkillCommand
            {
                Id = 0,
                Name = "Valid Name"
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(usc => usc.Id);
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdateSkillCommand
            {
                Id = 1,
                Name = string.Empty
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(usc => usc.Name);
        }

        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new UpdateSkillCommand
            {
                Id = 1,
                Name = new string('A', 51)
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(usc => usc.Name);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new UpdateSkillCommand
            {
                Id = 1,
                Name = "Valid Name"
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
