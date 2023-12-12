using FluentValidation.TestHelper;
using InternalSite.Application.Position.Queries.GetPosition;

namespace InternalSiteTests.Position.Validators
{
    /// <summary>
    /// Класс проверки валидатора GetPositionQueryValidator
    /// </summary>
    public class GetPositionQueryValidatorTester
    {
        private GetPositionQueryValidator validator;

        public GetPositionQueryValidatorTester()
        {
            validator = new GetPositionQueryValidator();
        }

        /// <summary>
        /// Метод проверки невалидного id
        /// </summary>
        [Fact]
        public void Should_have_error_when_Id_is_empty()
        {
            var query = new GetPositionQuery { Id = 0 };
            var result = validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(gpq => gpq.Id);
        }

        /// <summary>
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_Id_is_specified()
        {
            var query = new GetPositionQuery { Id = 1 };
            var result = validator.TestValidate(query);
            result.ShouldNotHaveValidationErrorFor(gpq => gpq.Id);
        }
    }
}