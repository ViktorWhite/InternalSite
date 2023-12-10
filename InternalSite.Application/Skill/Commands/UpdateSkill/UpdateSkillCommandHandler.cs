using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Skill.Commands.UpdateSkill
{
    /// <summary>
    /// Запрос на изменение навыка
    /// </summary>
    public class UpdateSkillCommand : IRequest
    {
        /// <summary>
        /// Идентификатор изменяемого навыка
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Измененное наименование навыка
        /// </summary>
        public string? Name { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на изменение навыка 
    /// </summary>
    /// <param name="dbContext"></param>
    public class UpdateSkillCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<UpdateSkillCommand>
    {
        /// <summary>
        /// Метод изменения навыка
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
        {
            var findSkill = await dbContext.Skills.FindAsync(request.Id, cancellationToken);

            if (findSkill is null)
            {
                throw new NotFoundException(nameof(Skill), request.Id);
            }

            findSkill.Name = request.Name;

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
