using FluentAssertions;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandValidatorTest
	{
		[Fact]
		public void WhenAuthorIdIsZeroOrLess_Validator_ShouldReturnError()
		{
			var command = new DeleteAuthorCommand(null) { AuthorId = 0 };
			var validator = new DeleteAuthorCommandValidator();

			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
