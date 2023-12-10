using InternalSite.Application.Category.Queries.Common;
using InternalSite.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Category.Queries.GetCategoriesQuery
{
    /// <summary>
    /// Запрос всех структурных подразделений
    /// </summary>
    public class GetListCategoryQuery : IRequest<List<CategoryVM>>
    { }

    /// <summary>
    /// Обработчик запросов всех структурных подразделений
    /// </summary>
    public class GetListCategoryQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetListCategoryQuery, List<CategoryVM>>
    {
        /// <summary>
        /// Метод возвращает все структурные подразделения
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<CategoryVM>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Categories.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name,
            }).ToListAsync(cancellationToken);
        }
    }
}
