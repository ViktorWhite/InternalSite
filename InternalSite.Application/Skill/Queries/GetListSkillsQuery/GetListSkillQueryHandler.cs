using InternalSite.Application.Interfaces;
using InternalSite.Application.Skill.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Skill.Queries.GetListSkillsQuery
{
    /// <summary>
    /// Запрос на предоставление всех навыков
    /// </summary>
    public class GetListSkillsQuery : IRequest<List<SkillVM>>
    { }

    /// <summary>
    /// Обработчик запроса на предоставление всех навыков
    /// </summary>
    public class GetListSkillQueryHandler(IInternalSiteDbContext dbContext) : IRequestHandler<GetListSkillsQuery, List<SkillVM>>
    {
        /// <summary>
        /// Метод предоставления всех навыков
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<SkillVM>> Handle(GetListSkillsQuery request, CancellationToken cancellationToken)
        {
            return await dbContext
                .Skills.Select(s => new SkillVM
            {
                Id = s.Id,
                Name = s.Name,
            }).ToListAsync(cancellationToken);
        }
    }
}
