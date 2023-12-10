using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации навыка
    /// </summary>
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        /// <summary>
        /// Метод настройки конфигурации навыка
        /// </summary>
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(skill => skill.Id);

            builder.Property(skill => skill.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
