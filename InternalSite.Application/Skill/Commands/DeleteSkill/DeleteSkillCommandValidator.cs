using FluentValidation;


namespace InternalSite.Application.Skill.Commands.DeleteSkill
{
    /// <summary>
    /// Валидатор запроса на удаление навыка по его идентификатору
    /// </summary>
    public class DeleteSkillCommandValidator : AbstractValidator<DeleteSkillCommand>
    {
        /// <summary>
        /// Настройка валидатора на удаление по его идентификатору
        /// </summary>
        public DeleteSkillCommandValidator()
        {
            RuleFor(dsc => dsc.Id).NotEmpty();
        }
    }
}
