using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using MediatR;

namespace InternalSite.Application.Skill.Commands.DeleteSkill
{
    /// <summary>
    /// Запрос на удаление навыка по его идентификатору
    /// </summary>
    public class DeleteSkillCommand : IRequest
    {
        /// <summary>
        /// Идентификатор удаляемого навыка
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на удаление навыка по его идентификатору
    /// </summary>
    public class DeleteSkillCommandHandler(IInternalSiteDbContext dbContext) : IRequestHandler<DeleteSkillCommand>
    {
        /// <summary>
        /// Мето удаления навыка по его идентификатору
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var findSkill = await dbContext.Skills.FindAsync(request.Id, cancellationToken);

            if (findSkill == null)
            {
                throw new NotFoundException(nameof(Skill), request.Id);
            }

            dbContext.Skills.Remove(findSkill);
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
