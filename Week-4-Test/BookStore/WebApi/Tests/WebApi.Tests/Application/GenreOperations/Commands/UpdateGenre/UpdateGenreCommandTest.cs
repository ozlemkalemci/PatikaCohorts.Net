using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public UpdateGenreCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenGenreDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var command = new UpdateGenreCommand(_context)
			{
				GenreId = 999, // olmayan genre
				Model = new UpdateGenreModel { Name = "Updated Genre" }
			};

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Güncellenecek tür bulunamadı");
		}
	}
}
