using System.Linq;
using System;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
	public class DeleteBookCommand
	{
		public int BookId { get; set; }
		private readonly IBookStoreDbContext _context;
		public DeleteBookCommand(IBookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var book = _context.Books.FirstOrDefault(x => x.Id == BookId);
			if (book == null)
				throw new InvalidOperationException("Kitap bulunamadı");

			_context.Books.Remove(book);
			_context.SaveChanges();
		}
	}
}
