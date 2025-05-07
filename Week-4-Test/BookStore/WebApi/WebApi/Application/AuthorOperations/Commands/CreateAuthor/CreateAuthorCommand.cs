using System;
using System.Linq;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
	public class CreateAuthorCommand
	{
		public CreateAuthorModel Model { get; set; }
		private readonly IBookStoreDbContext _context;

		public CreateAuthorCommand(IBookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var authorExists = _context.Authors.Any(x =>
				x.FirstName.ToLower() == Model.FirstName.ToLower() &&
				x.LastName.ToLower() == Model.LastName.ToLower());

			if (authorExists)
				throw new InvalidOperationException("Yazar zaten mevcut.");

			var author = new Author
			{
				FirstName = Model.FirstName,
				LastName = Model.LastName,
				BirthDate = Model.BirthDate
			};

			_context.Authors.Add(author);
			_context.SaveChanges();
		}
	}

	public class CreateAuthorModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
