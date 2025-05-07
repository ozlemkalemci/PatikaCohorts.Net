using FluentAssertions;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Tests.TestsSetup;
using Xunit;
using AutoMapper;
using System;
using WebApi.DbOperations;

namespace WebApi.Tests.Application.GenreOperations.Queries.GetGenreDetail
{
	public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetGenreDetailQueryTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
			_mapper = fixture.Mapper;
		}

		[Fact]
		public void WhenGenreDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var query = new GetGenreDetailQuery(_context, _mapper)
			{
				GenreId = 999
			};

			FluentActions.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Tür bulunamadı");
		}
	}
}
