using FluentAssertions;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommandValidatorTest
	{
		[Theory]
		[InlineData(0, "Eric", "Ries")]
		[InlineData(1, "", "Ries")]
		[InlineData(1, "Eric", "")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(int id, string name, string surname)
		{
			var command = new UpdateAuthorCommand(null)
			{
				AuthorId = id,
				Model = new UpdateAuthorModel
				{
					FirstName = name,
					LastName = surname
				}
			};

			var validator = new UpdateAuthorCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
