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

		public GetBooksQuery(BookStoreDbContext context)
		{
			_context = context;
		}

		public List<BooksViewModel> Handle()
		{
			var books = _context.Books.OrderBy(x => x.Id).ToList<Book>();

			List<BooksViewModel> vm = new List<BooksViewModel>();

			foreach (var book in books) 
			{
				vm.Add(new BooksViewModel()
				{
					PageCount = book.PageCount,
					Genre = ((GenreEnum)book.GenreId).ToString(),
					Title = book.Title,
					PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
				});
			}


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
