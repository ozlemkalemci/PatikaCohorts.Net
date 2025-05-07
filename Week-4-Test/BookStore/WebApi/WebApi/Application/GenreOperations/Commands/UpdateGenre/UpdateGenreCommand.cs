using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
	public class UpdateGenreCommand
	{
		public int GenreId { get; set; }
		public UpdateGenreModel Model { get; set; }
		private readonly IBookStoreDbContext _context;

		public UpdateGenreCommand(IBookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var genre = _context.Genres.FirstOrDefault(g => g.Id == GenreId);
			if (genre == null)
				throw new InvalidOperationException("Tür bulunamadı");

			genre.Name = Model.Name != default ? Model.Name : genre.Name;
			genre.IsActive = Model.IsActive != default ? Model.IsActive : genre.IsActive;

			_context.SaveChanges();
		}
	}

	public class UpdateGenreModel
	{
		public string Name { get; set; }
		public bool IsActive { get; set; }
	}
}
