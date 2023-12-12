using FluentValidation.TestHelper;
using InternalSite.Application.Category.Commands.UpdateCategory;

namespace InternalSiteTests.Category.Validators
{
    /// <summary>
    /// Класс тестирования UpdateCategoryCommandValidator 
    /// </summary>
    public class UpdateCategoryCommandValidatorTests
    {
        private readonly UpdateCategoryCommandValidator _validator;

        public UpdateCategoryCommandValidatorTests()
        {
            _validator = new UpdateCategoryCommandValidator();
        }

        /// <summary>
        /// Тест невалидного значения id
        /// </summary>
        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdateCategoryCommand
            {
                Id = 0,
                Name = "Valid Name"
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ucc => ucc.Id);
        }

        /// <summary>
        /// Тест невалидного значения Name
        /// </summary>
        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdateCategoryCommand
            {
                Id = 1,
                Name = string.Empty
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ucc => ucc.Name);
        }

        /// <summary>
        /// Тест невалидного значения Name
        /// </summary>
        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new UpdateCategoryCommand
            {
                Id = 1,
                Name = new string('A', 251)
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ucc => ucc.Name);
        }

        /// <summary>
        /// Тест валиднs[ значений
        /// </summary>
        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new UpdateCategoryCommand
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
