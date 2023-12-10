using FluentValidation.TestHelper;
using Xunit;

namespace InternalSite.Application.Person.Commands.DeletePerson.Tests
{
    public class DeletePersonCommandValidatorTests
    {
        private readonly DeletePersonCommandValidator _validator;

        public DeletePersonCommandValidatorTests()
        {
            _validator = new DeletePersonCommandValidator();
        }

        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new DeletePersonCommand
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
            var command = new DeletePersonCommand
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
