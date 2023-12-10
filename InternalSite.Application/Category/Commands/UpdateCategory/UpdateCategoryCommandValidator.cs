using FluentValidation;

namespace InternalSite.Application.Category.Commands.UpdateCategory
{
    /// <summary>
    /// Валидатор запроса на изменение структурного подразделения
    /// </summary>
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        /// <summary>
        /// Настройка валидатора на изменение структурного подразделения 
        /// </summary>
        public UpdateCategoryCommandValidator()
        {
            RuleFor(ucc => ucc.Id).NotEmpty();
            RuleFor(ucc => ucc.Name).NotEmpty().MaximumLength(250);
        }
    }
}