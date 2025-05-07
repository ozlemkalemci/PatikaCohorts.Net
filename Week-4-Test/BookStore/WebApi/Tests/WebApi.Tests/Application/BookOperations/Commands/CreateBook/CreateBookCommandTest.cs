using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.CreateCommand
{
	public class CreateBookCommandTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public CreateBookCommandTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}
		[Fact]
		public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
		{
			// arrange (hazırlık)
			var book = new Book() { Title = "test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1998, 01, 10), GenreId = 1, AuthorId = 1 };
			_context.Books.Add(book);
			_context.SaveChanges();

			CreateBookCommand command = new CreateBookCommand(_context,_mapper);	
			command.Model = new CreateBookCommand.CreateBookModel() 
			{
				Title = book.Title,
			};

			//act & assert(çalıştırma & doğrulama)

			FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");
		}

	}
}
