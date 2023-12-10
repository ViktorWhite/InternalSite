using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Skill.Commands.CreateSkill
{
    /// <summary>
    /// Запрос на создание нового навыка
    /// </summary>
    public class CreateSkillCommand : IRequest<int>
    {
        /// <summary>
        /// Наименование нового навыка
        /// </summary>
        public string? Name { get; set; } 
    }

    /// <summary>
    /// Обработчик запроса на создание нового навыка
    /// </summary>
    /// <param name="dbContext"></param>
    public class CreateSkillCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<CreateSkillCommand, int>
    {
        /// <summary>
        /// Метод создания нового навыка
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var newSkill = new Domain.Skill
            {
                Name = request.Name,
            };

            await dbContext.Skills.AddAsync(newSkill, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return newSkill.Id;
        }
    }
}
