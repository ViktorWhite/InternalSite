using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Category.Commands.DeleteCategory
{
    /// <summary>
    /// Запрос на удаление структурного подразделения по его идентификатору
    /// </summary>
    public class DeleteCategoryCommand : IRequest
    {
        /// <summary>
        /// Идентификатор удаляемого структурного подразделения
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на удаления структурного подразделения по его идентификатору
    /// </summary>
    public class DeleteCategoryCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<DeleteCategoryCommand>
    {
        /// <summary>
        /// Метод удаляет структурное подразделение по его идентификатору
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var findCategory = await dbContext.Categories.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Category), request.Id);

            dbContext.Categories.Remove(findCategory);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
