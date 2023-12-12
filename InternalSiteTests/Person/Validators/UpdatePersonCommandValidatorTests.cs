using FluentValidation.TestHelper;

namespace InternalSite.Application.Person.Commands.UpdatePerson.Tests
{
    /// <summary>
    /// Класс проверки валидатора UpdatePersonCommandValidator
    /// </summary>
    public class UpdatePersonCommandValidatorTests
    {
        private readonly UpdatePersonCommandValidator _validator;

        public UpdatePersonCommandValidatorTests()
        {
            _validator = new UpdatePersonCommandValidator();
        }

        /// <summary>
        /// Метод проверки невалидным id 
        /// </summary>
        [Fact]
        public void Id_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdatePersonCommand
            {
                Id = 0,
                Name = "ValidName",
                Surname = "ValidSurname",
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                UpdateSkillsOfPerson = { new UpdateSkillOfPerson { Id = 1, SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(upc => upc.Id);
        }

        /// <summary>
        /// Метод проверки невалидным Surname
        /// </summary>
        [Fact]
        public void Surname_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new UpdatePersonCommand
            {
                Id = 1,
                Name = "ValidName",
                Surname = string.Empty,
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                UpdateSkillsOfPerson = { new UpdateSkillOfPerson { Id = 1, SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(upc => upc.Surname);
        }

        /// <summary>
        /// Метод проверки валидными значениями 
        /// </summary>
        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new UpdatePersonCommand
            {
                Id = 1,
                Name = "ValidName",
                Surname = "ValidSurname",
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                UpdateSkillsOfPerson = { new UpdateSkillOfPerson { Id = 1, SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
