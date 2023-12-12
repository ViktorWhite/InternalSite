using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Commands.DeleteSkill.Tests
{
    /// <summary>
    /// Класс проверяет валидатор DeleteSkillCommandValidator
    /// </summary>
    public class DeleteSkillCommandValidatorTests
    {
        private readonly DeleteSkillCommandValidator _validator;

        public DeleteSkillCommandValidatorTests()
        {
            _validator = new DeleteSkillCommandValidator();
        }

        /// <summary>
        /// Тест на невалидный id
        /// </summary>
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


        /// <summary>
        /// Тест на валидные данные
        /// </summary>
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
