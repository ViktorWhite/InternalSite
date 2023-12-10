using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации работника
    /// </summary>
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        /// <summary>
        /// Метод настройки конфигурации работника
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(peson => peson.Id);

            builder.Property(person => person.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(person => person.Surname)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(person => person.Patronymic)
                .HasMaxLength(30);

            builder.Property(person => person.Birthday)
                .IsRequired();

            builder.Property(person => person.PhoneNumber)
            .IsRequired();

            builder.Property(person => person.CategoryId)
                .IsRequired();

            builder.Property(person => person.PositionId)
                .IsRequired();

            builder.HasMany(person => person.SkillsOfPerson)
                .WithOne()
                .HasForeignKey(sop => sop.PersonId);
        }
    }
}
