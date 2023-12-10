using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using InternalSite.Application.Person.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Person.Queries.GetPersonQuery
{
    /// <summary>
    /// Запрос на предоставление сотрудника по его идентификатору
    /// </summary>
    public class GetPersonQuery : IRequest<PersonVM>
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчика запроса на предоставление сотрудника по его идентификатору
    /// </summary>
    public class GetPersonQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetPersonQuery, PersonVM>
    {
        /// <summary>
        /// Метод на предоставление сотрудника по его идентификатору
        /// </summary>
        public async Task<PersonVM> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var dbPerson = await dbContext.Persons
                .Include(p => p.SkillsOfPerson)
                .FirstOrDefaultAsync(p => p.Id == request.Id)
                ?? throw new NotFoundException(nameof(Person), request.Id);

            return new PersonVM
            {
                Id = dbPerson.Id,
                Name = dbPerson.Name,
                Surname = dbPerson.Surname,
                Patronymic = dbPerson.Patronymic,
                Birthday = dbPerson.Birthday,
                PhoneNumber = dbPerson.PhoneNumber,
                CategoryId = dbPerson.CategoryId,
                PositionId = dbPerson.PositionId,
                SkillsOfPersonVM = dbPerson.SkillsOfPerson
                .Select(skillOfPerson => new SkillOfPersonVM
                {
                    Id = skillOfPerson.Id,
                    PersonId = skillOfPerson.PersonId,
                    SkillId = skillOfPerson.SkillId,
                    Level = skillOfPerson.Level,
                }).ToList()
            };
        }
    }
}
