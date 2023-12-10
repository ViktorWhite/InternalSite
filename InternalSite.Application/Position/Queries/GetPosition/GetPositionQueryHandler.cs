using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using InternalSite.Application.Position.Queries.Common;
using MediatR;

namespace InternalSite.Application.Position.Queries.GetPosition
{
    /// <summary>
    /// Запрос на предоставление должности по ее идентификатору
    /// </summary>
    public class GetPositionQuery : IRequest<PositionVM>
    {
        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на предоставление должности по ее идентификатору
    /// </summary>
    public class GetPositionQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetPositionQuery, PositionVM>
    {
        /// <summary>
        /// Метод запрашивает должность по ее идентификатору
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<PositionVM> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            var findPosition = await dbContext.Positions.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Position), request.Id);

            return new PositionVM
            {
                Id = findPosition.Id,
                Name = findPosition.Name,
                CategoryId = findPosition.CategoryId,
            };
        }
    }
}
