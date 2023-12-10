using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации должности
    /// </summary>
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        /// <summary>
        /// Метод настройки конфигурации должности
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(position => position.Id);

            builder.Property(position => position.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(position => position.Persons)
                .WithOne()
                .HasForeignKey(person => person.PositionId);   

            builder.HasMany(position => position.SkillsOfPosition)
                .WithOne()
                .HasForeignKey(sop => sop.PositionId);
        }
    }
}
