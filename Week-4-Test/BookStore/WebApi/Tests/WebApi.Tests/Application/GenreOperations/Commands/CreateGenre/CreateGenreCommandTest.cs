using FluentAssertions;
using System;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public CreateGenreCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenGenreNameAlreadyExists_InvalidOperationException_ShouldBeThrown()
		{
			var genre = new Genre { Name = "Mystery" };
			_context.Genres.Add(genre);
			_context.SaveChanges();

			var command = new CreateGenreCommand(_context);
			command.Model = new CreateGenreModel { Name = "Mystery" };

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.And.Message.Should().Be("Tür zaten mevcut.");
		}
	}
}
