using FluentValidation;

namespace InternalSite.Application.Person.Queries.GetPersonQuery
{
    /// <summary>
    /// Валидатор запроса сотрудника по его идентификатору
    /// </summary>
    public class GetPersonQueryValidator : AbstractValidator<GetPersonQuery>
    {
        /// <summary>
        /// Настройка валидатора запроса сотрудника по его идентификатору
        /// </summary>
        public GetPersonQueryValidator()
        {
            RuleFor(gpq => gpq.Id).NotEmpty();
        }
    }
}
