using FluentAssertions;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorDetailQueryValidatorTest
	{
		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void WhenAuthorIdIsInvalid_Validator_ShouldReturnError(int authorId)
		{
			var query = new GetAuthorDetailQuery(null, null)
			{
				AuthorId = authorId
			};

			var validator = new GetAuthorDetailQueryValidator();
			var result = validator.Validate(query);

			result.Errors.Count.Should().BeGreaterThan(0);
		}

		[Fact]
		public void WhenAuthorIdIsValid_Validator_ShouldNotReturnError()
		{
			var query = new GetAuthorDetailQuery(null, null)
			{
				AuthorId = 1
			};

			var validator = new GetAuthorDetailQueryValidator();
			var result = validator.Validate(query);

			result.Errors.Count.Should().Be(0);
		}
	}
}
