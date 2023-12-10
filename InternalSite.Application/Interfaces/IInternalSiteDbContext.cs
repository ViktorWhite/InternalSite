using InternalSite.Domain;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Application.Interfaces
{
    public interface IInternalSiteDbContext
    {
        DbSet<Domain.Category> Categories { get; set; }

        DbSet<Domain.Position> Positions { get; set; }

        DbSet<SkillOfPerson> SkillsOfPerson { get; set; }

        DbSet<SkillOfPosition> SkillsOfPosition { get; set; }

        DbSet<Domain.Person> Persons { get; set; }

        DbSet<Domain.Skill> Skills { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
