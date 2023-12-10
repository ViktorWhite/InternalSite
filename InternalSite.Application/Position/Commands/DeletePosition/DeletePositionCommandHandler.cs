using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Position.Commands.DeletePosition
{
    /// <summary>
    /// Запрос на удаление должности по ее идентификатору
    /// </summary>
    public class DeletePositionCommand : IRequest
    {
        /// <summary>
        /// Идентификатор удаляемой должности
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на удаление должности по ее идентификатору
    /// </summary>
    public class DeletePositionCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<DeletePositionCommand>
    {
        /// <summary>
        /// Метод удаляет должность по ее идентификатору
        /// </summary>
        /// <param name="dbContext"></param>
        public async Task Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var deletePosition = await dbContext.Positions.FindAsync(request.Id, cancellationToken)
                ?? throw new NotFoundException(nameof(Person), request.Id);
      
            dbContext.Positions.Remove(deletePosition);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
