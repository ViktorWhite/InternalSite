using FluentValidation;

namespace InternalSite.Application.Category.Queries.GetCategoryQuery
{
    /// <summary>
    /// Валидатор запроса структурного подразделения по идентификатору
    /// </summary>
    public class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
    {
        /// <summary>
        /// Настройка валидатора запроса структурного подразделения по идентификатору
        /// </summary>
        public GetCategoryQueryValidator()
        {
            RuleFor(gcq => gcq.Id).NotEmpty().NotNull();
        }
    }
}
