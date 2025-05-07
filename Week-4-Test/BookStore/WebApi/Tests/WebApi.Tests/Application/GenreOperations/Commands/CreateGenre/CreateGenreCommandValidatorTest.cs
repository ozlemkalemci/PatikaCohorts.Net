using FluentAssertions;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandValidatorTest
	{
		[Theory]
		[InlineData("")]
		[InlineData("  ")]
		public void WhenNameIsInvalid_Validator_ShouldReturnError(string name)
		{
			var command = new CreateGenreCommand(null);
			command.Model = new CreateGenreModel { Name = name };

			var validator = new CreateGenreCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
