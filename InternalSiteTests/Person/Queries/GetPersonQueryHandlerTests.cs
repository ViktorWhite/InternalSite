using InternalSite.Application.Person.Queries.GetPersonQuery;
using Shouldly;
using InternalSite.Application.Person.Queries.Common;

namespace InternalSiteTests.Person.Queries
{
    /// <summary>
    /// Тест проверяет запрос сотрудника по его идентификатору
    /// </summary>
    public class GetPersonQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetPersonQueryHandler_Success()
        {
            // Arrange
            var handler = new GetPersonQueryHandler(Context);

            // Act
            var result = await handler.Handle(
                new GetPersonQuery
                {
                   Id = 1,
                }, CancellationToken.None);

            //Assert
            result.ShouldBeOfType<PersonVM>();
            result.Name.ShouldBe("Максим");
            result.Surname.ShouldBe("Бойко");
            result.Patronymic.ShouldBe("Владимирович");
            result.Birthday.ShouldBe(Context.Persons.First().Birthday);
            result.PhoneNumber.ShouldBe("8-913-842-42-12");
            result.CategoryId.ShouldBe(1);
            result.PositionId.ShouldBe(1);
            result.SkillsOfPersonVM.ShouldNotBeNull();
            result.SkillsOfPersonVM.Count.ShouldBe(2);
            result.SkillsOfPersonVM[0].Id.ShouldBe(1);
            result.SkillsOfPersonVM[0].PersonId.ShouldBe(1);
            result.SkillsOfPersonVM[0].SkillId.ShouldBe(1);
            result.SkillsOfPersonVM[0].Level.ShouldBe(10);
            result.SkillsOfPersonVM[1].Id.ShouldBe(2);
            result.SkillsOfPersonVM[1].PersonId.ShouldBe(1);
            result.SkillsOfPersonVM[1].SkillId.ShouldBe(2);
            result.SkillsOfPersonVM[1].Level.ShouldBe(8);
        }
    }
}
