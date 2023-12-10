using FluentValidation;

namespace InternalSite.Application.Position.Commands.CreatePosition
{
    /// <summary>
    /// Валидатор запроса создания новой должности
    /// </summary>
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        /// <summary>
        /// Настройка валидатора создания новой должности
        /// </summary>
        public CreatePositionCommandValidator()
        {
            RuleFor(cpc => cpc.Name).NotEmpty().MaximumLength(250);
        }
    }
}
