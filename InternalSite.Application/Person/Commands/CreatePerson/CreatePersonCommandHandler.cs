using InternalSite.Application.Interfaces;
using InternalSite.Domain;
using MediatR;

namespace InternalSite.Application.Person.Commands.CreatePerson
{
    /// <summary>
    /// Навык и его уровень работника
    /// </summary>
    public class CreatedSkillOfPerson
    {
        /// <summary>
        /// Идентификатор навыка
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Уровень навыка по шкале до 10 
        /// </summary>
        public int Level { get; set; }
    }

    /// <summary>
    /// Запрос на создание нового работника
    /// </summary>
    public class CreatePersonCommand : IRequest<int>
    {
        /// <summary>
        /// Имя нового работника
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Фамилия нового работника
        /// </summary>
        public string? Surname { get; set; }

        /// <summary>
        /// Отчество нового работника
        /// </summary>
        public string? Patronymic { get; set; }

        /// <summary>
        /// Дата рождения нового работника
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Номер телефона нового работника
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Идентдификатор структурного подразделения
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Идентификатор долнжости структурного подразделения
        /// </summary>
        public int PositionId { get; set; }

        /// <summary>
        /// Список навыков с их оценкой
        /// </summary>
        public List<CreatedSkillOfPerson> CreatedSkillsOfPerson { get; set; } = new List<CreatedSkillOfPerson>();
    }

    /// <summary>
    /// Метод создания нового работника с его навыками
    /// </summary>
    /// <param name="dbContext"></param>
    public class CreatePersonCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<CreatePersonCommand, int>
    {
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var newPerson = new Domain.Person
            {
                Name = request.Name,
                Surname = request.Surname,
                Patronymic = request.Patronymic,
                Birthday = request.Birthday,
                PhoneNumber = request.PhoneNumber,
                CategoryId = request.CategoryId,
                PositionId = request.PositionId,
            };

            var skillOfPersonDb = request.CreatedSkillsOfPerson
                .Select(skill => new SkillOfPerson
                {
                    Level = skill.Level,
                    PersonId = newPerson.Id,
                    SkillId = skill.SkillId,
                }).ToList();

            newPerson.SkillsOfPerson = skillOfPersonDb;

            await dbContext.Persons.AddAsync(newPerson, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newPerson.Id;
        }
    }
}
