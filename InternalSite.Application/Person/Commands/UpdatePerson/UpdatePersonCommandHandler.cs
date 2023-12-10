using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using InternalSite.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Person.Commands.UpdatePerson
{
    /// <summary>
    /// Информация об обновленном навыке сотрудника
    /// </summary>
    public class UpdateSkillOfPerson
    {
        /// <summary>
        /// Идентификатор информации о навыке сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Обновленный идентификатор навыка сотрудника
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Обновленный уровень навыка сотрудника по 10 бальной шкале
        /// </summary>
        public int Level { get; set; }
    }

    /// <summary>
    /// Запрос на обновление данных сотрудника
    /// </summary>
    public class UpdatePersonCommand : IRequest
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Обновленное имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Обновленное фамилия
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Обновленное отчество
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Обновленная дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Обновленный телефонный номер
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Обновленный идентификатор структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Обновленный идентификатор должности структурного подразделения
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Список обновленных навыков сотрудника
        /// </summary>
        public List<UpdateSkillOfPerson> UpdateSkillsOfPerson { get; set; } = new List<UpdateSkillOfPerson>();
    }

    /// <summary>
    /// Обработчик запроса обновления данных сотрудника
    /// </summary>
    /// <param name="dbContext"></param>
    public class UpdatePersonCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<UpdatePersonCommand>
    {
        /// <summary>
        /// Метод обновления данных сотрудника
        /// </summary>
        /// <param name="dbContext"></param>
        public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var dbPerson = await dbContext.Persons
            .Include(p => p.SkillsOfPerson)
            .FirstOrDefaultAsync(p => p.Id == request.Id)
            ?? throw new NotFoundException(nameof(Person), request.Id);

            dbPerson.Name = request.Name;
            dbPerson.Surname = request.Surname;
            dbPerson.Patronymic = request.Patronymic;
            dbPerson.Birthday = request.Birthday;
            dbPerson.PhoneNumber = request.PhoneNumber;
            dbPerson.CategoryId = request.CategoryId;
            dbPerson.PositionId = request.PositionId;

            var updatedSkillsOfPersonIds = request.UpdateSkillsOfPerson.Select(s => s.Id).ToList();
            var deleteSkillsOfPerson = dbPerson.SkillsOfPerson.Where(s => !updatedSkillsOfPersonIds.Contains(s.Id)).ToList();

            if (deleteSkillsOfPerson.Any())
            {
                dbContext.SkillsOfPerson.RemoveRange(deleteSkillsOfPerson);
            }

            foreach (var skillDto in request.UpdateSkillsOfPerson)
            {
                var dbPersonSkillOfPerson = dbPerson.SkillsOfPerson.FirstOrDefault(x => x.Id == skillDto.Id);

                if (dbPersonSkillOfPerson == null)
                {
                    var newSkillsOfPerson = new SkillOfPerson
                    {
                        SkillId = skillDto.SkillId,
                        PersonId = request.Id,
                        Level = skillDto.Level,
                    };

                    dbPerson.SkillsOfPerson.Add(newSkillsOfPerson);
                }
                else
                {
                    dbPersonSkillOfPerson.SkillId = skillDto.SkillId;
                    dbPersonSkillOfPerson.PersonId = request.Id;
                    dbPersonSkillOfPerson.Level = skillDto.Level;
                }

                await dbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
