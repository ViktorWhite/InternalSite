using FluentValidation;

namespace InternalSite.Application.Skill.Queries.GetSkillQuery
{
    /// <summary>
    /// Валидатор запроса навыка по его идентификатору
    /// </summary>
    public class GetSkillQueryValidator : AbstractValidator<GetSkillQuery>
    {
        /// <summary>
        /// Настройка валидатора запроса навыка его идентификатору
        /// </summary>
        public GetSkillQueryValidator()
        {
            RuleFor(gsq => gsq.Id).NotEmpty();
        }
    }
}
