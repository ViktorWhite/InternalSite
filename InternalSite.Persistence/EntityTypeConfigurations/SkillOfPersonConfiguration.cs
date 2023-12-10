using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации информации о навыке сотрудника
    /// </summary>
    public class SkillOfPersonConfiguration : IEntityTypeConfiguration<SkillOfPerson>
    {
        /// <summary>
        /// Метод настройки конфигурации информации о навыке сотрудника
        /// </summary>
        public void Configure(EntityTypeBuilder<SkillOfPerson> builder)
        {
            builder.HasKey(sop => sop.Id);

            builder.Property(sop => sop.PersonId)
                .IsRequired(); 

            builder.Property(sop => sop.SkillId)
                .IsRequired();

            builder.Property(sop => sop.Level)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("[Level]", "[Level] > 0 AND [Level] <= 10").HasName("CK_Skill_Level"));
        }
    }
}
