using FluentAssertions;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Queries.GetBookDetail
{
	public class GetBookDetailQueryValidatorTest
	{
		[Fact]
		public void WhenBookIdIsInvalid_Validator_ShouldReturnError()
		{
			var query = new GetBookDetailQuery(null, null) { BookId = 0 };

			var validator = new GetBookDetailQueryValidator();
			var result = validator.Validate(query);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
