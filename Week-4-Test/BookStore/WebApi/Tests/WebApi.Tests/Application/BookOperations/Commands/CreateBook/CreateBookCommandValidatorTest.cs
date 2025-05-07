using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.DbOperations;
using WebApi.Entities;
using WebApi.Tests.TestsSetup;
using Xunit;

namespace WebApi.Tests.Application.BookOperations.Commands.CreateBook
{
	public class CreateBookCommandValidatorTest : IClassFixture<CommonTestFixture>
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public CreateBookCommandValidatorTest(CommonTestFixture testFixture)
		{
			_context = testFixture.Context;
			_mapper = testFixture.Mapper;
		}
		[Theory]
		[InlineData("Lord Of The Rings",0,0)]
		[InlineData("Lord Of The Rings",0,1)]
		[InlineData("",1,1)]
		[InlineData("Lor",0,0)]
		public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount, int genreId)
		{
			// arrange (hazırlık)
			CreateBookCommand command = new CreateBookCommand(_context, _mapper);
			command.Model = new CreateBookCommand.CreateBookModel()
			{
				Title = "",
				GenreId = 0,
				PageCount =0,
				PublishDate = DateTime.Now.Date.AddYears(-1)
			};

			//act & assert(çalıştırma & doğrulama)
			CreateBookCommandValidator validator = new CreateBookCommandValidator();
			var result = validator.Validate(command);
			result.Errors.Count.Should().BeGreaterThan(0);

		}
	}
}
