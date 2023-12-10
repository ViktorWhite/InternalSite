using FluentValidation.TestHelper;

namespace InternalSite.Application.Position.Commands.CreatePosition.Tests
{
    public class CreatePositionCommandValidatorTests
    {
        private readonly CreatePositionCommandValidator _validator;

        public CreatePositionCommandValidatorTests()
        {
            _validator = new CreatePositionCommandValidator();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new CreatePositionCommand
            {
                Name = string.Empty,
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cpc => cpc.Name);
        }

        [Fact]
        public void Name_ShouldNotExceedMaximumLength()
        {
            // Arrange
            var command = new CreatePositionCommand
            {
                Name = new string('A', 251),
                CategoryId = 1
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(cpc => cpc.Name);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new CreatePositionCommand
            {
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
