using FluentValidation.TestHelper;
using InternalSite.Application.Category.Commands.CreateCategory;

namespace InternalSiteTests.Category.Validators
{
    /// <summary>
    /// Класс тестирования CreateCategoryCommandValidator 
    /// </summary>
    public class CreateCategoryCommandValidatorTests
    {
        private readonly CreateCategoryCommandValidator _validator;

        public CreateCategoryCommandValidatorTests()
        {
            _validator = new CreateCategoryCommandValidator();
        }

        /// <summary>
        /// Тест на пустую строку
        /// </summary>
        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new CreateCategoryCommand
            {
                Name = string.Empty
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ccc => ccc.Name);
        }

        /// <summary>
        /// Тест на размер имени больший, чем нужно
        /// </summary>
        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new CreateCategoryCommand
            {
                Name = new string('A', 251)
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ccc => ccc.Name);
        }

        /// <summary>
        /// Тест на валидное имя
        /// </summary>
        [Fact]
        public void Name_ShouldBeValid()
        {
            // Arrange
            var command = new CreateCategoryCommand
            {
                Name = "Valid Name"
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
