using FluentValidation;

namespace InternalSite.Application.Person.Queries.GetListPersonQuery
{
    public class GetListPersonQueryValidator : AbstractValidator<GetListPersonQuery>
    {
        public GetListPersonQueryValidator()
        {
            RuleFor(glpq => glpq.SkillsOfPersonVM).NotNull().NotEmpty();
        }
    }
}
