using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
	{
		public CreateAuthorCommandValidator()
		{
			RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(2);
			RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(2);
			RuleFor(x => x.Model.BirthDate).NotEmpty().LessThan(System.DateTime.Now);
		}
	}
}
