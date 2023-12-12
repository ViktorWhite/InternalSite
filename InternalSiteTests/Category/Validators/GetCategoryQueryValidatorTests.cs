using FluentValidation.TestHelper;
using InternalSite.Application.Category.Queries.GetCategoryQuery;

namespace InternalSiteTests.Category.Validators
{
    /// <summary>
    /// Класс тестирования валидатора GetCategoryQueryValidator
    /// </summary>
    public class GetCategoryQueryValidatorTests
    {
        private GetCategoryQueryValidator _validator;

        public GetCategoryQueryValidatorTests()
        {
            _validator = new GetCategoryQueryValidator();
        }

        /// <summary>
        /// Тест на невалидное значение id
        /// </summary>
        [Fact]
        public void Should_have_error_when_Id_is_empty()
        {
            var query = new GetCategoryQuery { Id = 0 };
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(gcq => gcq.Id);
        }

        /// <summary>
        /// Тест на валидное значение id
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_Id_is_specified()
        {
            var query = new GetCategoryQuery { Id = 1 };
            var result = _validator.TestValidate(query);
            result.ShouldNotHaveValidationErrorFor(gcq => gcq.Id);
        }
    }
}