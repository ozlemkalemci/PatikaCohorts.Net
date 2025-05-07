using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
	public class UpdateBookCommand
	{
		public UpdateBookModel Model { get; set; }
		public int BookId { get; set; }
		private readonly BookStoreDbContext _context;
		public UpdateBookCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
			if (book == null)
				throw new InvalidOperationException("Kitap bulunamadı");

			book.Title = Model.Title != default ? Model.Title : book.Title;
			book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
			_context.SaveChanges();
		}

		public class UpdateBookModel
		{
			public string Title { get; set; }
			public int GenreId { get; set; }
		}
	}
}
