using FluentValidation;

namespace InternalSite.Application.Position.Commands.DeletePosition
{
    /// <summary>
    /// Валидатор запроса на удаление должности по ее идентификатору
    /// </summary>
    public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
    {
        /// <summary>
        /// Настройка валидатора удаления должности по ее идентификатору
        /// </summary>
        public DeletePositionCommandValidator()
        {
            RuleFor(dpc => dpc.Id).NotEmpty();
        }
    }
}
