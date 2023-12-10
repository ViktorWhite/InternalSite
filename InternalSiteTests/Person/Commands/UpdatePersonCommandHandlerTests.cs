using InternalSite.Application.Common.Exceptions;
using InternalSite.Application.Person.Commands.UpdatePerson;

namespace InternalSiteTests.Person.Commands
{
    /// <summary>
    /// Тесты проверяют команду изменения сотрудника и его навыков
    /// </summary>
    public class UpdatePersonCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdatePersonCommandHandler_Success()
        {
            // Arrange 
            var handler = new UpdatePersonCommandHandler(Context);
            var idUpdatePerson = 1;
            var nameUpdatePerson = "Измененное имя";
            var surnameUpdatePerson = "Измененное фамилия";
            var patronymicUpdatePerson = "Измененное отчество";
            var birthdayUpdatePerson = DateTime.Now;
            var phoneNumberUpdatePerson = "1234567890";
            var categoryIdUpdatePerson = 1;
            var positionIdUpdatePerson = 1;
            var skillsUpdatePerson = new List<UpdateSkillOfPerson>
            {
                new UpdateSkillOfPerson
                {
                    Id = 1,
                    SkillId = 1,
                    Level = 10
                },
                new UpdateSkillOfPerson
                {
                    Id = 2,
                    SkillId = 2,
                    Level = 8
                },
                new UpdateSkillOfPerson
                {
                    SkillId = 3,
                    Level = 5
                }
            };
            // Act
            await handler.Handle(new UpdatePersonCommand
            {
                Id = idUpdatePerson,
                Name = nameUpdatePerson,
                Surname = surnameUpdatePerson,
                Patronymic = patronymicUpdatePerson,
                Birthday = birthdayUpdatePerson,
                PhoneNumber = phoneNumberUpdatePerson,
                CategoryId = categoryIdUpdatePerson,
                PositionId = positionIdUpdatePerson,
                UpdateSkillsOfPerson = skillsUpdatePerson,
            }, CancellationToken.None);

            var updatedPerson = await Context.Persons.FindAsync(idUpdatePerson);

            // Assert
            Assert.NotNull(updatedPerson);
            Assert.Equal(updatedPerson.Id, idUpdatePerson);
            Assert.Equal(updatedPerson.Name, nameUpdatePerson);
            Assert.Equal(updatedPerson.Surname, surnameUpdatePerson);
            Assert.Equal(updatedPerson.Patronymic, patronymicUpdatePerson);
            Assert.Equal(updatedPerson.Birthday, birthdayUpdatePerson);
            Assert.Equal(updatedPerson.PhoneNumber, phoneNumberUpdatePerson);
            Assert.Equal(updatedPerson.CategoryId, categoryIdUpdatePerson);
            Assert.Equal(updatedPerson.PositionId, positionIdUpdatePerson);
            Assert.Equal(updatedPerson.SkillsOfPerson.Count, skillsUpdatePerson.Count);

            foreach (var skill in updatedPerson.SkillsOfPerson)
            {
                Assert.True(skill.Id != 0);
                Assert.Contains(skillsUpdatePerson, s => 
                s.SkillId == skill.SkillId && 
                s.Level == skill.Level);

                Assert.Equal(skill.PersonId, updatedPerson.Id);
            }
        }

        [Fact]
        public async Task UpdatePersonCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdatePersonCommandHandler(Context);
            var idUpdatePerson = 10;
            var nameUpdatePerson = "Измененное имя";
            var surnameUpdatePerson = "Измененное фамилия";
            var patronymicUpdatePerson = "Измененное отчество";
            var birthdayUpdatePerson = DateTime.Now;
            var phoneNumberUpdatePerson = "1234567890";
            var categoryIdUpdatePerson = 1;
            var positionIdUpdatePerson = 1;
            var skillsUpdatePerson = new List<UpdateSkillOfPerson>();
            
            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdatePersonCommand
                {
                Id = idUpdatePerson,
                Name = nameUpdatePerson,
                Surname = surnameUpdatePerson,
                Patronymic = patronymicUpdatePerson,
                Birthday = birthdayUpdatePerson,
                PhoneNumber = phoneNumberUpdatePerson,
                CategoryId = categoryIdUpdatePerson,
                PositionId = positionIdUpdatePerson,
                UpdateSkillsOfPerson = skillsUpdatePerson,
                }, CancellationToken.None));
        }
    }
}
