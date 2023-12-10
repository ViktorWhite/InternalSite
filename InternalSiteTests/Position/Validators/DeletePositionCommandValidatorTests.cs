using FluentValidation.TestHelper;

namespace InternalSite.Application.Position.Commands.DeletePosition.Tests
{
    public class DeletePositionCommandValidatorTests
    {
        private readonly DeletePositionCommandValidator _validator;

        public DeletePositionCommandValidatorTests()
        {
            _validator = new DeletePositionCommandValidator();
        }

        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new DeletePositionCommand
            {
                Id = 0
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(dpc => dpc.Id);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new DeletePositionCommand
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
