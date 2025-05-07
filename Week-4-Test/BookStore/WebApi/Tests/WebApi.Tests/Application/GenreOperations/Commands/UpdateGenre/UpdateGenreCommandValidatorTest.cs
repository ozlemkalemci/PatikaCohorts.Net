using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandValidatorTest
	{
		[Theory]
		[InlineData(0, "")]
		[InlineData(1, " ")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id, string name)
		{
			var command = new UpdateGenreCommand(null)
			{
				GenreId = id,
				Model = new UpdateGenreModel { Name = name }
			};

			var validator = new UpdateGenreCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
