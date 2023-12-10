using FluentValidation.TestHelper;

namespace InternalSite.Application.Person.Commands.CreatePerson.Tests
{
    public class CreatePersonCommandValidatorTests
    {
        private readonly CreatePersonCommandValidator _validator;

        public CreatePersonCommandValidatorTests()
        {
            _validator = new CreatePersonCommandValidator();
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new CreatePersonCommand
            {
                Name = string.Empty,
                Surname = "ValidSurname",
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                CreatedSkillsOfPerson = { new CreatedSkillOfPerson { SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ccc => ccc.Name);
        }

        [Fact]
        public void Surname_ShouldNotBeEmpty()
        {
            // Arrange
            var command = new CreatePersonCommand
            {
                Name = "ValidName",
                Surname = string.Empty,
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                CreatedSkillsOfPerson = { new CreatedSkillOfPerson { SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldHaveValidationErrorFor(ccc => ccc.Surname);
        }

        [Fact]
        public void Command_ShouldBeValid()
        {
            // Arrange
            var command = new CreatePersonCommand
            {
                Name = "ValidName",
                Surname = "ValidSurname",
                Patronymic = "ValidPatronymic",
                Birthday = DateTime.Now,
                PhoneNumber = "12345678901",
                CategoryId = 1,
                PositionId = 1,
                CreatedSkillsOfPerson = { new CreatedSkillOfPerson { SkillId = 1, Level = 5 } }
            };

            // Act
            var result = _validator.TestValidate(command);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
