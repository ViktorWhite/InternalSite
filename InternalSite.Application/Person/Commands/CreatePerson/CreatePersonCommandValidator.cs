using FluentValidation;

namespace InternalSite.Application.Person.Commands.CreatePerson
{
    /// <summary>
    /// Валидатор создания запроса создания сотрудника
    /// </summary>
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        /// <summary>
        /// Настройка валидатора создания сотрудника
        /// </summary>
        public CreatePersonCommandValidator()
        {
            RuleFor(ccc => ccc.Name).NotEmpty().MaximumLength(30);
            RuleFor(ccc => ccc.Surname).NotEmpty().MaximumLength(30);
            RuleFor(ccc => ccc.Patronymic).NotEmpty().MaximumLength(30);
            RuleFor(ccc => ccc.Birthday).NotEmpty();
            RuleFor(ccc => ccc.PhoneNumber).NotEmpty().MaximumLength(11);
            RuleFor(ccc => ccc.CategoryId).NotEmpty();
            RuleFor(ccc => ccc.PositionId).NotEmpty();
            RuleForEach(p => p.CreatedSkillsOfPerson).ChildRules(csop =>
            {
                csop.RuleFor(csop => csop.Level).NotEmpty().NotNull().Must(value => value > 0 && value < 10).WithMessage("Уровень должен быть от 1 до 10");
                csop.RuleFor(csop => csop.SkillId).NotEmpty().NotNull().NotEqual(0);
            });
        }
    }
}
