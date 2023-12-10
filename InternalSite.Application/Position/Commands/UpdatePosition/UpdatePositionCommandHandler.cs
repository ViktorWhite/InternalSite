using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Position.Commands.UpdatePosition
{
    /// <summary>
    /// Запрос на изменение должности
    /// </summary>
    public class UpdatePositionCommand : IRequest
    {
        /// <summary>
        /// Идентификатор изменеяемой должности
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Измененное наименование должности
        /// </summary>
        public string? Name { get; set; } 

        /// <summary>
        /// Измененная категория структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на изменение должности
    /// </summary>
    public class UpdatePositionCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<UpdatePositionCommand>
    {
        /// <summary>
        /// Метод изменяет наименование и идентификатор структурного подразделения должности
        /// </summary>
        /// <param name="dbContext"></param>
        public async Task Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var updatePosition = await dbContext.Positions.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Position), request.Id);
            
            updatePosition.Name = request.Name;
            updatePosition.CategoryId = request.CategoryId;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
