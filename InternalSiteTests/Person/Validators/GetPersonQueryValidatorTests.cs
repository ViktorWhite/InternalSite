using FluentValidation.TestHelper;

namespace InternalSite.Application.Person.Queries.GetPersonQuery.Tests
{
    /// <summary>
    /// Класс тестирования GetPersonQueryValidatorTests
    /// </summary>
    public class GetPersonQueryValidatorTests
    {
        private GetPersonQueryValidator _validator;

        public GetPersonQueryValidatorTests()
        {
            _validator = new GetPersonQueryValidator();
        }

        /// <summary>
        /// Метод тестирования невалидным id
        /// </summary>
        [Fact]
        public void Should_have_error_when_Id_is_empty()
        {
            var model = new GetPersonQuery { Id = 0 };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(gpq => gpq.Id);
        }

        /// <summary>
        /// Метод тестирования валидным id
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_Id_is_specified()
        {
            var model = new GetPersonQuery { Id = 1 };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(gpq => gpq.Id);
        }
    }
}