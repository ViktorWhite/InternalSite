using FluentValidation;

namespace InternalSite.Application.Category.Commands.CreateCategory
{
    /// <summary>
    /// Валидатора запроса на создание нового структурного подразделения
    /// </summary>
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        /// <summary>
        /// Настройка валидатора запроса создания структурного подразделения
        /// </summary>
        public CreateCategoryCommandValidator()
        {
            RuleFor(ccc => ccc.Name).NotEmpty().MaximumLength(250);
        }
    }
}
