using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.UpdateSkill.Tests
{
    /// <summary>
    /// Класс проверяет валидатор UpdateSkillCommandValidator
    /// </summary>
    public class UpdateSkillCommandValidatorTests
    {
        private readonly UpdateSkillCommandValidator _validator;


        public UpdateSkillCommandValidatorTests()
        {
            _validator = new UpdateSkillCommandValidator();
        }


        /// <summary>
        /// Тест на невалидный id
        /// </summary>
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

        /// <summary>
        /// Тест на невалидный Name
        /// </summary>
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

        /// <summary>
        /// Тест на невалидный Name
        /// </summary>
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

        /// <summary>
        /// Тест на валидные данные
        /// </summary>
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
