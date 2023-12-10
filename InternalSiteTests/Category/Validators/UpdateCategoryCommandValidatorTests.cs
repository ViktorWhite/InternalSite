using FluentValidation.TestHelper;
using InternalSite.Application.Category.Commands.UpdateCategory;

namespace InternalSiteTests.Category.Validators
{
    public class UpdateCategoryCommandValidatorTests
    {
        private readonly UpdateCategoryCommandValidator _validator;

        public UpdateCategoryCommandValidatorTests()
        {
            _validator = new UpdateCategoryCommandValidator();
        }

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
