using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
	public class CreateGenreCommand
	{
		public CreateGenreModel Model { get; set; }
		private readonly BookStoreDbContext _context;

		public CreateGenreCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
			if (genre != null)
				throw new InvalidOperationException("Tür zaten mevcut");

			genre = new Genre
			{
				Name = Model.Name,
				IsActive = true
			};

			_context.Genres.Add(genre);
			_context.SaveChanges();
		}
	}

	public class CreateGenreModel
	{
		public string Name { get; set; }
	}
}
