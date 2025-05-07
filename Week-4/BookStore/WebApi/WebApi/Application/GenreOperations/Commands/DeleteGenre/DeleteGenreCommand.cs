using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
	public class DeleteGenreCommand
	{
		public int GenreId { get; set; }
		private readonly BookStoreDbContext _context;

		public DeleteGenreCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var genre = _context.Genres.FirstOrDefault(g => g.Id == GenreId);
			if (genre == null)
				throw new InvalidOperationException("Tür bulunamadı");

			_context.Genres.Remove(genre);
			_context.SaveChanges();
		}
	}
}
