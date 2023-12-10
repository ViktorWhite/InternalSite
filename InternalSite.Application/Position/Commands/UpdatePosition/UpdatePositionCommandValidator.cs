using FluentValidation;

namespace InternalSite.Application.Position.Commands.UpdatePosition
{
    /// <summary>
    /// Валидатор запроса на изменение должности
    /// </summary>
    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        /// <summary>
        /// Настройка валидатора изменения должности
        /// </summary>
        public UpdatePositionCommandValidator()
        {
            RuleFor(upc => upc.Name).NotEmpty().MaximumLength(250);
        }
    }
}
