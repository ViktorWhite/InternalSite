using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.CreateSkill.Tests
{
    /// <summary>
    /// Класс проверят валидатор CreateSkillCommandValidator
    /// </summary>
    public class CreateSkillCommandValidatorTests
    {
        private readonly CreateSkillCommandValidator _validator;

        public CreateSkillCommandValidatorTests()
        {
            _validator = new CreateSkillCommandValidator();
        }

        /// <summary>
        /// Тест на невалидный Name
        /// </summary>
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

        /// <summary>
        /// Тест на невалидный Name
        /// </summary>
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

        /// <summary>
        /// Тест c валидными данными
        /// </summary>
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
