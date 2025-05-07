using FluentAssertions;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Queries.GetGenreDetail
{
	public class GetGenreDetailQueryValidatorTest
	{
		[Fact]
		public void WhenGenreIdIsInvalid_Validator_ShouldReturnError()
		{
			var query = new GetGenreDetailQuery(null, null) { GenreId = 0 };
			var validator = new GetGenreDetailQueryValidator();

			var result = validator.Validate(query);

			result.Errors.Count.Should().BeGreaterThan(0);
		}
	}
}
