using InternalSite.Application.Person.Commands.CreatePerson;

namespace InternalSiteTests.Person.Commands
{
    /// <summary>
    /// Тест проверяет команду создания сотрудника и его навыков
    /// </summary>
    public class CreatePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreatePersonCommandHandlerTests_Success()
        {
            // Arrange
            var handler = new CreatePersonCommandHandler(Context);
            var nameCreatePerson = "Новое имя";
            var surnameCreatePerson = "Новая фамилия";
            var patronymicCreatePerson = "Новое отчество";
            var birthdayCreatePerson = DateTime.Now;
            var phoneNumberCreatePerson = "1234567890";
            var categoryIdCreatePerson = 1;
            var positionIdCreatePerson = 1;
            var skillsCreatePerson = new List<CreatedSkillOfPerson>
            {
                new CreatedSkillOfPerson
                {
                    SkillId = 1,
                    Level = 10
                },
                new CreatedSkillOfPerson
                {
                    SkillId = 2,
                    Level = 8
                }
            };

            // Act
            var createPersonId = await handler.Handle(
                new CreatePersonCommand
                {
                    Name = nameCreatePerson,
                    Surname = surnameCreatePerson,
                    Patronymic = patronymicCreatePerson,
                    Birthday = birthdayCreatePerson,
                    PhoneNumber = phoneNumberCreatePerson,
                    CategoryId = categoryIdCreatePerson,
                    PositionId = positionIdCreatePerson,
                    CreatedSkillsOfPerson = skillsCreatePerson
                }, CancellationToken.None);

            var createdPerson = await Context.Persons.FindAsync(createPersonId);

            Assert.NotNull(createdPerson);
            Assert.Equal(createdPerson.Id, createPersonId);
            Assert.Equal(createdPerson.Name, nameCreatePerson);
            Assert.Equal(createdPerson.Surname, surnameCreatePerson);
            Assert.Equal(createdPerson.Patronymic, patronymicCreatePerson);
            Assert.Equal(createdPerson.Birthday, birthdayCreatePerson);
            Assert.Equal(createdPerson.PhoneNumber, phoneNumberCreatePerson);
            Assert.Equal(createdPerson.CategoryId, categoryIdCreatePerson);
            Assert.Equal(createdPerson.PositionId, positionIdCreatePerson);
            Assert.Equal(createdPerson.SkillsOfPerson.Count, skillsCreatePerson.Count);

            foreach (var skill in createdPerson.SkillsOfPerson)
            {
                Assert.Contains(skillsCreatePerson, s => s.SkillId == skill.SkillId
                && s.Level == skill.Level);
                Assert.Equal(skill.PersonId, createdPerson.Id);
                Assert.True(skill.Id != 0);
            }
        }
    }
}
