using FluentAssertions;
using System;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Queries.GetBookDetail
{
	public class GetBookDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public GetBookDetailQueryTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}

		[Fact]
		public void WhenBookDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var query = new GetBookDetailQuery(_context, null) { BookId = 999 };

			FluentActions.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
		}
	}
}
