using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using InternalSite.Application.Person.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Person.Queries.GetListPersonQuery
{
    /// <summary>
    /// Запрос на предоставление списка сотрудников с их навыками
    /// </summary>
    public class GetListPersonQuery : IRequest<List<PersonVM>>
    {
        public int? PositionId { get; set; }
        public List<int> SkillsOfPersonVM { get; set; }
        public bool IsAnySkill { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на предоставление списка сотрудников с их навыками
    /// </summary>
    /// <param name="dbContext"></param>
    public class GetListPersonQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetListPersonQuery, List<PersonVM>>
    {
        /// <summary>
        /// Метод обработчика запроса на предоставление списка сотрудников с их навыками
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<List<PersonVM>> Handle(GetListPersonQuery request, CancellationToken cancellationToken)
        {
            var result = await dbContext.Persons
               .Include(p => p.SkillsOfPerson)
               .Select(person => new PersonVM
               {
                   Id = person.Id,
                   Name = person.Name,
                   Surname = person.Surname,
                   Patronymic = person.Patronymic,
                   Birthday = person.Birthday,
                   PhoneNumber = person.PhoneNumber,
                   CategoryId = person.CategoryId,
                   PositionId = person.PositionId,
                   SkillsOfPersonVM = person.SkillsOfPerson.Select(skill => new SkillOfPersonVM
                   {
                       Id = skill.Id,
                       PersonId = skill.PersonId,
                       Level = skill.Level,
                       SkillId = skill.SkillId
                   })
                   .ToList()
               })
               .ToListAsync();

            result = result.Where(x =>
                (request.PositionId == null || x.PositionId == request.PositionId) && 
                (request.IsAnySkill
                    ? x.SkillsOfPersonVM.Any(skill => request.SkillsOfPersonVM.Contains(skill.SkillId)) 
                    : x.SkillsOfPersonVM.Count == request.SkillsOfPersonVM.Count && 
                      request.SkillsOfPersonVM.All(skillId => x.SkillsOfPersonVM.Any(skill => skill.SkillId == skillId))
                ))
                .ToList();

            return result;
        }
    }
}
