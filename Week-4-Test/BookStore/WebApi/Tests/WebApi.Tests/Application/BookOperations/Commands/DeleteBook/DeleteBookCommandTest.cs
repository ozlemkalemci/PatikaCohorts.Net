using FluentAssertions;
using System;
using WebApi.Application.BookOperations.Commands.DeleteBook;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.DeleteBook
{
	public class DeleteBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public DeleteBookCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
		}

		[Fact]
		public void WhenBookDoesNotExist_InvalidOperationException_ShouldBeThrown()
		{
			var command = new DeleteBookCommand(_context) { BookId = 999 };

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap bulunamadı");
		}
	}
}
