using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Person.Commands.DeletePerson
{
    /// <summary>
    /// Запрос на удаление работника по его идентификатору
    /// </summary>
    public class DeletePersonCommand : IRequest
    {
        /// <summary>
        /// Идентинификатор удаляемого работника
        /// </summary>
        public int Id { get; set; }
    }


    /// <summary>
    /// Обработчик запроса на удаление работника по его идентификатору
    /// </summary>
    public class DeletePersonCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<DeletePersonCommand>
    {
        /// <summary>
        /// Метод удаления работника по его идентинификатору
        /// </summary>
        /// <param name="dbContext"></param>
        public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var findPerson = await dbContext.Persons.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Person), request.Id);
            
            dbContext.Persons.Remove(findPerson);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
