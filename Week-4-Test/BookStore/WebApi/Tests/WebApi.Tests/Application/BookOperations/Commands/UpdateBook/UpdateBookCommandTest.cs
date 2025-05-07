using FluentAssertions;
using System;
using WebApi.Application.BookOperations.Commands.UpdateBook;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.UpdateBook
{
	public class UpdateBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public UpdateBookCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenBookDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var command = new UpdateBookCommand(_context)
			{
				BookId = 999, // olmayan kitap
				Model = new UpdateBookCommand.UpdateBookModel { Title = "Updated", GenreId = 1 }
			};

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Kitap bulunamadı");
		}
	}
}
