using FluentValidation;

namespace InternalSite.Application.Person.Commands.UpdatePerson
{
    /// <summary>
    /// Валидатор запроса изменения сотрудника
    /// </summary>
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        /// <summary>
        /// Настройка валидатора изменения сотрудника
        /// </summary>
        public UpdatePersonCommandValidator()
        {
            RuleFor(upc => upc.Id).NotEmpty();
            RuleFor(ccc => ccc.Surname).NotEmpty().MaximumLength(30);
            RuleFor(ccc => ccc.Patronymic).NotEmpty().MaximumLength(30);
            RuleFor(ccc => ccc.Birthday).NotEmpty();
            RuleFor(ccc => ccc.PhoneNumber).NotEmpty().MaximumLength(11);
            RuleFor(ccc => ccc.CategoryId).NotEmpty();
            RuleFor(ccc => ccc.PositionId).NotEmpty();
            RuleForEach(p => p.UpdateSkillsOfPerson).ChildRules(usop =>
            {
                usop.RuleFor(usop => usop.Level).NotEmpty().NotNull().Must(value => value > 0 && value < 10).WithMessage("Уровень должен быть от 1 до 10");
                usop.RuleFor(usop => usop.SkillId).NotEmpty().NotNull().NotEqual(0);
            });
        }
    }
}
