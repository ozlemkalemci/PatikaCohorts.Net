using FluentAssertions;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.DeleteBook
{
	public class DeleteBookCommandValidatorTest
	{
		[Fact]
		public void WhenBookIdIsInvalid_Validator_ShouldReturnError()
		{
			var command = new DeleteBookCommand(null) { BookId = 0 };
			var validator = new DeleteBookCommandValidator();

			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
