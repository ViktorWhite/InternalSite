using InternalSite.Application.Interfaces;
using InternalSite.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace InternalSite.Persistence
{
    /// <summary>
    /// Класс создания контекста базы данных
    /// </summary>
    public class InternalSiteDbContext : DbContext, IInternalSiteDbContext
    {
        public InternalSiteDbContext(DbContextOptions<InternalSiteDbContext> options)
           : base(options) { }

        /// <summary>
        /// Контекст структурных подразделений
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Контекст должностей
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// Контекст сотрудников
        /// </summary>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Контекст инфомрации о навыках сотрудников
        /// </summary>
        public DbSet<SkillOfPerson> SkillsOfPerson { get; set; }

        /// <summary>
        /// Контекст инфомрации о навыках должностей
        /// </summary>
        public DbSet<SkillOfPosition> SkillsOfPosition { get; set; }

        /// <summary>
        /// Контекст навыков
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Метод, интергриующий настройки конфигурации в базу данных
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
