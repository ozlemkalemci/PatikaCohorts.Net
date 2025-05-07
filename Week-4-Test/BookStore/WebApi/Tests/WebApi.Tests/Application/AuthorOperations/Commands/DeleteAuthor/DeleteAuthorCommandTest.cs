using FluentAssertions;
using System;
using System.Linq;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.DbOperations;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;

		public DeleteAuthorCommandTest(CommonTestFixture fixture)
		{
			_context = fixture.Context;
		}

		[Fact]
		public void WhenAuthorHasBooks_InvalidOperationException_ShouldBeThrown()
		{
			var authorIdWithBook = _context.Books.First().AuthorId;

			var command = new DeleteAuthorCommand(_context)
			{
				AuthorId = authorIdWithBook
			};

			FluentActions.Invoking(() => command.Handle())
				.Should().Throw<InvalidOperationException>()
				.WithMessage("Yazarın yayında olan kitabı mevcut. Önce kitap silinmelidir.");
		}
	}
}
