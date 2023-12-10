using InternalSite.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InternalSiteTests.Common
{
    /// <summary>
    /// Класс создает тестовую базу данных
    /// </summary>
    public class InternalSiteContextFactory
    {
        public static InternalSiteDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InternalSiteDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new InternalSiteDbContext(options);

            context.Database.EnsureCreated();

            context.Categories.AddRange(
                new InternalSite.Domain.Category
                {
                    Id = 1,
                    Name = "АСУТП"
                },
                new InternalSite.Domain.Category
                {
                    Id = 2,
                    Name = "ИИС"
                }
                );

            context.Positions.AddRange(
                new InternalSite.Domain.Position
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Инженер"
                },
                new InternalSite.Domain.Position
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Контролер"
                }
                );

            context.Skills.AddRange(
                new InternalSite.Domain.Skill
                {
                    Id = 1,
                    Name = "Усидчивость"
                },
                new InternalSite.Domain.Skill
                {
                    Id = 2,
                    Name = "Целеустремленность"
                }
                );

            context.Persons.AddRange(
              new InternalSite.Domain.Person
              {
                  Id = 1,
                  Name = "Максим",
                  Surname = "Бойко",
                  Patronymic = "Владимирович",
                  Birthday = DateTime.Now,
                  PhoneNumber = "8-913-842-42-12",
                  CategoryId = 1,
                  PositionId = 1,
                  SkillsOfPerson = new List<InternalSite.Domain.SkillOfPerson>
                  {
                      new InternalSite.Domain.SkillOfPerson
                      {
                          Id = 1,
                          SkillId = 1,
                          Level = 10
                      },
                      new InternalSite.Domain.SkillOfPerson
                      {
                          Id = 2,
                          SkillId = 2,
                          Level = 8
                      }
                  }
              },
              new InternalSite.Domain.Person
              {
                  Id = 2,
                  Name = "Анатолий",
                  Surname = "Деведенко",
                  Patronymic = "Владимирович",
                  Birthday = DateTime.Now,
                  PhoneNumber = "8-913-851-48-28",
                  CategoryId = 1,
                  PositionId = 1,
                  SkillsOfPerson = new List<InternalSite.Domain.SkillOfPerson>
                  {
                      new InternalSite.Domain.SkillOfPerson
                      {
                          Id = 3,
                          PersonId = 2,
                          SkillId = 1,
                          Level = 10
                      },
                      new InternalSite.Domain.SkillOfPerson
                      {
                          Id = 4,
                          PersonId = 2,
                          SkillId = 2,
                          Level = 8
                      }
                  }
              }
              );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(InternalSiteDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
