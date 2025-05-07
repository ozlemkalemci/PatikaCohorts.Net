using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
	public class GetBooksQuery
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;
		public GetBooksQuery(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public List<BooksViewModel> Handle()
		{
			var books = _context.Books.OrderBy(x => x.Id).ToList<Book>();

			List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(books);


			return vm;
		}

		public class BooksViewModel
		{
			public int Id { get; set; }
			public string Title { get; set; }
			public string Genre { get; set; }
			public int PageCount { get; set; }
			public string PublishDate { get; set; }
		}
	}
}
