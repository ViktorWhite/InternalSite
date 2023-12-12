using FluentValidation.TestHelper;

namespace InternalSite.Application.Skill.Queries.GetSkillQuery.Tests
{
    /// <summary>
    /// Класс проверки валидатора GetSkillQueryValidatorTest
    /// </summary>
    public class GetSkillQueryValidatorTest
    {
        private GetSkillQueryValidator validator;


        public GetSkillQueryValidatorTest()
        {
            validator = new GetSkillQueryValidator();
        }


        /// <summary>
        /// Тетс на невалидный id
        /// </summary>
        [Fact]
        public void Should_have_error_when_Id_is_empty()
        {
            var model = new GetSkillQuery { Id = 0 };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(gsq => gsq.Id);
        }


        /// <summary>
        /// Тетс на валидные данные
        /// </summary>
        [Fact]
        public void Should_not_have_error_when_Id_is_specified()
        {
            var model = new GetSkillQuery { Id = 1 };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(gsq => gsq.Id);
        }
    }
}