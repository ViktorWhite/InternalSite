using FluentValidation;

namespace InternalSite.Application.Category.Commands.DeleteCategory
{
    /// <summary>
    /// Валидатор запроса на удаление структурного подразделения
    /// </summary>
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        /// <summary>
        /// Настройка валидатора запроса на удаление структурного подразделения 
        /// </summary>
        public DeleteCategoryCommandValidator() 
        {
            RuleFor(dcc => dcc.Id).NotEmpty().NotNull();
        }
    }
}
