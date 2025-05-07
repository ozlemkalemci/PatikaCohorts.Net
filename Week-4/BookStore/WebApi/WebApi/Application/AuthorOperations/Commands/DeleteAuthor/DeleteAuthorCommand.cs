using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
	public class DeleteAuthorCommand
	{
		public int AuthorId { get; set; }
		private readonly BookStoreDbContext _context;

		public DeleteAuthorCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
			if (author == null)
				throw new InvalidOperationException("Yazar bulunamadı.");

			bool hasPublishedBooks = _context.Books.Any(b => b.AuthorId == AuthorId);
			if (hasPublishedBooks)
				throw new InvalidOperationException("Yayında kitabı olan yazar silinemez.");

			_context.Authors.Remove(author);
			_context.SaveChanges();
		}
	}
}
