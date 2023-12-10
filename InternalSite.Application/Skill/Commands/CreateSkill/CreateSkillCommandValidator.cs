using FluentValidation;

namespace InternalSite.Application.Skill.Commands.CreateSkill
{
    /// <summary>
    /// Валидатор запроса создания навыка 
    /// </summary>
    public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
    {
        /// <summary>
        /// Настройка валидатора создания навыка
        /// </summary>
        public CreateSkillCommandValidator()
        {
            RuleFor(csc => csc.Name).NotEmpty().MaximumLength(50);
        }
    }
}
