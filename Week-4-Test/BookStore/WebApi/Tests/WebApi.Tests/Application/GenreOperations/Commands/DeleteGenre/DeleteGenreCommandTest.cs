using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.DeleteGenre
{
	public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public DeleteGenreCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenGenreHasBooks_InvalidOperationException_ShouldBeThrown()
		{
			var genreIdWithBook = _context.Books.First().GenreId;

			var command = new DeleteGenreCommand(_context) { GenreId = genreIdWithBook };

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.And.Message.Should().Be("Bu türe ait kitaplar mevcut, önce kitaplar silinmelidir.");
		}
	}
}
