using InternalSite.Application.Category.Queries.Common;
using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Category.Queries.GetCategoryQuery
{
    /// <summary>
    /// Запрос структурного подразделения по его идентификатору
    /// </summary>
    public class GetCategoryQuery : IRequest<CategoryVM>
    {
        /// <summary>
        /// Идентификатор запрашиваемого структурного подразделения
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса структурного подразделения по его идентификатору
    /// </summary>
    public class GetCategoryQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetCategoryQuery, CategoryVM>
    {
        /// <summary>
        /// Метод возвращает запрошенное структурное подразделение по его id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<CategoryVM> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var findCategory = await dbContext.Categories.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Category), request.Id);

            return new CategoryVM
            {
                Id = findCategory.Id,
                Name = findCategory.Name,
            };
        }
    }
}
