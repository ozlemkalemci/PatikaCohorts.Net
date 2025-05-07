using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
	public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
	{
		public CreateBookCommandValidator()
		{
			RuleFor(x => x.Model.GenreId).GreaterThan(0);
			RuleFor(x => x.Model.PageCount).GreaterThan(0);
			RuleFor(x => x.Model.Title).NotEmpty();
			RuleFor(x => x.Model.PublishDate.Date).NotEmpty().LessThan(System.DateTime.Now);
		}
	}
}
