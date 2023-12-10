using FluentValidation;

namespace InternalSite.Application.Skill.Commands.UpdateSkill
{
    /// <summary>
    /// Валидтор запроса на изменение навыка
    /// </summary>
    public class UpdateSkillCommandValidator : AbstractValidator<UpdateSkillCommand>
    {
        /// <summary>
        /// Настройка валидатора на изменение навыка
        /// </summary>
        public UpdateSkillCommandValidator()
        {
            RuleFor(usc => usc.Id).NotEmpty();
            RuleFor(usc => usc.Name).NotEmpty().MaximumLength(50);
        }
    }
}
