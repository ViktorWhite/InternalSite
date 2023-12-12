using FluentValidation.TestHelper;

namespace InternalSite.Application.Person.Commands.DeletePerson.Tests
{
    /// <summary>
    /// Класс проверки валидатора DeletePersonCommandValidator
    /// </summary>
    public class DeletePersonCommandValidatorTests
    {
        private readonly DeletePersonCommandValidator _validator;

        public DeletePersonCommandValidatorTests()
        {
            _validator = new DeletePersonCommandValidator();
        }

        /// <summary>
        /// Метод проверки невалидными данными
        /// </summary>
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

        /// <summary>
        /// Метод проверки валидными данными
        /// </summary>
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
