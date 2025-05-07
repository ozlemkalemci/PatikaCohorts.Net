using FluentAssertions;
using System;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public CreateAuthorCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenAuthorAlreadyExists_InvalidOperationException_ShouldBeThrown()
		{
			// Seed'den gelen yazarın aynısı
			var command = new CreateAuthorCommand(_context);
			command.Model = new CreateAuthorModel
			{
				FirstName = "Eric",
				LastName = "Ries",
				BirthDate = new DateTime(1978, 09, 22)
			};

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Yazar zaten mevcut.");
		}
	}
}
