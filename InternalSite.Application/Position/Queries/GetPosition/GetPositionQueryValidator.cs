using FluentValidation;

namespace InternalSite.Application.Position.Queries.GetPosition
{
    /// <summary>
    /// Валидатор запроса на получение должности по ее идентификатору
    /// </summary>
    public class GetPositionQueryValidator : AbstractValidator<GetPositionQuery>
    {
        /// <summary>
        /// Настройка валидатора на получение должности по ее идентификатору
        /// </summary>
        public GetPositionQueryValidator()
        {
            RuleFor(gpq => gpq.Id).NotEmpty();
        }
    }
}
