using System;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail
{
	public class GetBookDetailQuery
	{
		private readonly BookStoreDbContext _context;
		public int BookId { get; set; }

		public GetBookDetailQuery(BookStoreDbContext context)
		{
			_context = context;
		}

		public BooksDetailViewModel Handle()
		{
			var book = _context.Books.Where(x => x.Id == BookId).FirstOrDefault();
			if (book == null)
				throw new InvalidOperationException("Kitap bulunamadı");
			BooksDetailViewModel vm = new BooksDetailViewModel();
			vm.Title = book.Title;
			vm.PageCount = book.PageCount;
			vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
			vm.Genre = ((GenreEnum)book.GenreId).ToString();
			return vm;
		}

		public class BooksDetailViewModel
		{ 
			public string Title { get; set; }
			public string Genre { get; set; }
			public int PageCount { get; set; }
			public string PublishDate { get; set; }
		}
	}
}
