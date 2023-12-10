using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации навыка должности
    /// </summary>
    public class SkillOfPositionConfiguration : IEntityTypeConfiguration<SkillOfPosition>
    {
        public void Configure(EntityTypeBuilder<SkillOfPosition> builder)
        {
            builder.HasKey(sop => sop.Id);

            builder.Property(sop => sop.PositionId)
                .IsRequired();

            builder.Property(sop => sop.SkillId)
                .IsRequired();
        }
    }
}
