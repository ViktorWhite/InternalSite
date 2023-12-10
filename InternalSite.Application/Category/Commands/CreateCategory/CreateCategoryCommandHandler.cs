using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Category.Commands.CreateCategory
{
    /// <summary>
    /// Запрос на создание нового структурного подразделения
    /// </summary>
    public class CreateCategoryCommand : IRequest<int>
    {
        /// <summary>
        /// Наименование нового структурного подразделения
        /// </summary>
        public string? Name { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на создание нового структурного подразделения
    /// </summary>
    public class CreateCategoryCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<CreateCategoryCommand, int>
    {
        /// <summary>
        /// Метод создает новое структурное подразделение и присваивает ему идентификатор
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var newCategory = new Domain.Category
            {
                Name = request.Name,
            };

            await dbContext.Categories.AddAsync(newCategory, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newCategory.Id;
        }
    }
}
