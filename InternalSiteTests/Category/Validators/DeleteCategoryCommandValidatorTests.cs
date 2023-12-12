using FluentValidation.TestHelper;
using InternalSite.Application.Category.Commands.DeleteCategory;

namespace InternalSiteTests.Category.Validators
{
    /// <summary>
    /// Класс тестирования DeleteCategoryCommandValidator 
    /// </summary>
    public class DeleteCategoryCommandValidatorTests
    {
        private readonly DeleteCategoryCommandValidator _validator;

        public DeleteCategoryCommandValidatorTests()
        {
            _validator = new DeleteCategoryCommandValidator();
        }

        /// <summary>
        /// Тест на невалидное значение
        /// </summary>
        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new DeleteCategoryCommand
            {
                Id = 0
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(dcc => dcc.Id);
        }

        /// <summary>
        /// Тест на валидное значение
        /// </summary>
        [Fact]
        public void Id_ShouldBeValid()
        {
            // Arrange
            var command = new DeleteCategoryCommand
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
