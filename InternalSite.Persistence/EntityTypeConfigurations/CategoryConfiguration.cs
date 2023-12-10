using InternalSite.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternalSite.Persistence.EntityTypeConfigurations
{
    /// <summary>
    /// Класс настройки конфигурации структурного подразделения
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        /// <summary>
        /// Метод настройки конфигурации структурного подразделения
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasMany(category => category.Positions)
                .WithOne()
                .HasForeignKey(position => position.CategoryId);
        }
    }
}
