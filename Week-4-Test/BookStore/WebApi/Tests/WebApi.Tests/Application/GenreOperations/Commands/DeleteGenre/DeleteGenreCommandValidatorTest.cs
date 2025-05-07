using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.DeleteGenre
{
	public class DeleteGenreCommandValidatorTest
	{
		[Fact]
		public void WhenGenreIdIsInvalid_Validator_ShouldReturnError()
		{
			var command = new DeleteGenreCommand(null) { GenreId = 0 };
			var validator = new DeleteGenreCommandValidator();

			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
