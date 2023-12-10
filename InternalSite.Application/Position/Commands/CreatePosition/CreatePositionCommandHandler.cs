using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Position.Commands.CreatePosition
{
    /// <summary>
    /// Запрос на создание новой должности
    /// </summary>
    public class CreatePositionCommand : IRequest<int>
    {
        /// <summary>
        /// Наименование новой должности
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Идентификатор структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на создание новой должности
    /// </summary>
    /// <param name="dbContext"></param>
    public class CreatePositionCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<CreatePositionCommand, int>
    {
        /// <summary>
        /// Метод создает новою должность и присваивает ей идентификатор
        /// </summary>
        /// <param name="dbContext"></param>
        public async Task<int> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var newPosition = new Domain.Position
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
            };

            await dbContext.Positions.AddAsync(newPosition, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return newPosition.Id;
        }
    }
}
