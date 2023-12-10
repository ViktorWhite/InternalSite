using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Category.Commands.UpdateCategory
{
    /// <summary>
    /// Запрос на изменение структурного подразделения
    /// </summary>
    public class UpdateCategoryCommand : IRequest
    {
        /// <summary>
        /// Идентификатор изменяемого структурного подразделения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Измененное имя структурного подразделения
        /// </summary>
        public string? Name { get; set; }
    }

    /// <summary>
    /// Обработчик запроса изменения структурного подразделения
    /// </summary>
    public class UpdateCategoryCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<UpdateCategoryCommand>
    {
        /// <summary>
        /// Метод изменяет наименование структурного подразделения
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var updateCategory = await dbContext.Categories.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Category), request.Id);
     
            updateCategory.Name = request.Name;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
