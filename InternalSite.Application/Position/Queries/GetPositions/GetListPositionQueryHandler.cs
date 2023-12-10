using InternalSite.Application.Interfaces;
using InternalSite.Application.Position.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Position.Queries.GetPositions
{
    /// <summary>
    /// Запрос на предоствление всех должностей 
    /// </summary>
    public class GetListPositionQuery : IRequest<List<PositionVM>>
    { }

    /// <summary>
    /// Обработчик запроса на предоставление всех должностей
    /// </summary>
    /// <param name="dbContext"></param>
    public class GetListPositionQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetListPositionQuery, List<PositionVM>>
    {
        /// <summary>
        /// Метод запрашивает все должности
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<PositionVM>> Handle(GetListPositionQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Positions.Select(p => new PositionVM
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
            }).ToListAsync(cancellationToken);
        }
    }
}
