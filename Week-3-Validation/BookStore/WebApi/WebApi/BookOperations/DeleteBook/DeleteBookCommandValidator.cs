using FluentValidation;
using WebApi.BookOperations.DeleteBook;

namespace WebApi.BookOperations.DeleteBook
{
	public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
	{
		public DeleteBookCommandValidator()
		{
			RuleFor(x => x.BookId).GreaterThan(0);
		}
	}
}
