using FluentAssertions;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.UpdateBook
{
	public class UpdateBookCommandValidatorTest
	{
		[Theory]
		[InlineData(0, "", 0)]
		[InlineData(-1, "Up", 1)]
		[InlineData(1, "", 1)]
		public void WhenInvalidInputsGiven_Validator_ShouldReturnErrors(int bookId, string title, int genreId)
		{
			var command = new UpdateBookCommand(null)
			{
				BookId = bookId,
				Model = new UpdateBookCommand.UpdateBookModel
				{
					Title = title,
					GenreId = genreId
				}
			};

			var validator = new UpdateBookCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
