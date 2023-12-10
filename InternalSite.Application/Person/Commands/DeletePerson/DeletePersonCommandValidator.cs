using FluentValidation;

namespace InternalSite.Application.Person.Commands.DeletePerson
{
    /// <summary>
    /// Валидатор запроса на удаление сотрудника
    /// </summary>
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        /// <summary>
        /// Настройка валидатора удаления сотрудника
        /// </summary>
        public DeletePersonCommandValidator()
        {
            RuleFor(dpc => dpc.Id).NotEmpty();
        }
    }
}
