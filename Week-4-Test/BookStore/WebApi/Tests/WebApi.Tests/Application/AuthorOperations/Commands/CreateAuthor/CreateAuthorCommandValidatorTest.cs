using FluentAssertions;
using System;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandValidatorTest
	{
		[Theory]
		[InlineData("", "Ries")]
		[InlineData("Eric", "")]
		[InlineData("", "")]
		public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name, string surname)
		{
			var command = new CreateAuthorCommand(null);
			command.Model = new CreateAuthorModel
			{
				FirstName = name,
				LastName = surname,
				BirthDate = new DateTime(1990, 1, 1)
			};

			var validator = new CreateAuthorCommandValidator();
			var result = validator.Validate(command);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
