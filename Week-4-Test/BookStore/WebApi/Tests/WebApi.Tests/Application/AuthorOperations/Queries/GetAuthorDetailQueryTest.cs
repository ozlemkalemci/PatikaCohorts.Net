using FluentAssertions;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Tests.TestsSetup;
using Xunit;
using AutoMapper;
using System;
using WebApi.DbOperations;

namespace WebApi.Tests.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorDetailQueryTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetAuthorDetailQueryTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
			_mapper = fixture.Mapper;
		}

		[Fact]
		public void WhenAuthorDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var query = new GetAuthorDetailQuery(_context, _mapper)
			{
				AuthorId = 999
			};

			FluentActions.Invoking(() => query.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Yazar bulunamadı");
		}
	}
}
