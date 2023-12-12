using FluentValidation.TestHelper;

namespace InternalSite.Application.Position.Commands.UpdatePosition.Tests
{
    /// <summary>
    /// Класс проверки валидатора UpdatePositionCommandValidator
    /// </summary>
    public class UpdatePositionCommandValidatorTests
    {
        private readonly UpdatePositionCommandValidator _validator;

        public UpdatePositionCommandValidatorTests()
        {
            _validator = new UpdatePositionCommandValidator();
        }

        /// <summary>
        /// Метод проверки невалидного Name
        /// </summary>
        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdatePositionCommand
            {
                Id = 1,
                Name = string.Empty,
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(upc => upc.Name);
        }

        /// <summary>
        /// Метод проверки невалидного Name
        /// </summary>
        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new UpdatePositionCommand
            {
                Id = 1,
                Name = new string('A', 251),
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(upc => upc.Name);
        }

        /// <summary>
        /// Метод проверки валидных данных
        /// </summary>
        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new UpdatePositionCommand
            {
                Id = 1,
                Name = "Valid Name",
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
