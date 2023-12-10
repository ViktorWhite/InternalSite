using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Interfaces;
using InternalSite.Application.Skill.Queries.Common;
using MediatR;

namespace InternalSite.Application.Skill.Queries.GetSkillQuery
{
    /// <summary>
    /// Запрос на предоставление навыка по его идентификатору
    /// </summary>
    public class GetSkillQuery : IRequest<SkillVM>
    {
        /// <summary>
        /// Идентификатор запрашиваемого навыка
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Обработчик запроса на предоставление навыка по его идентификатору
    /// </summary>
    public class GetSkillQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetSkillQuery, SkillVM>
    {
        /// <summary>
        /// Метод запроса навыка по его идентификатору
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<SkillVM> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var findSkill = await dbContext.Skills.FindAsync(request.Id, cancellationToken) 
                ?? throw new NotFoundException(nameof(Skill), request.Id);

            return new SkillVM
            {
                Id = findSkill.Id,
                Name = findSkill.Name,
            };
        }
    }
}
