using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
	public class UpdateAuthorCommand
	{
		public int AuthorId { get; set; }
		public UpdateAuthorModel Model { get; set; }
		private readonly BookStoreDbContext _context;

		public UpdateAuthorCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
			if (author == null)
				throw new InvalidOperationException("Yazar bulunamadı.");

			author.FirstName = string.IsNullOrWhiteSpace(Model.FirstName) ? author.FirstName : Model.FirstName;
			author.LastName = string.IsNullOrWhiteSpace(Model.LastName) ? author.LastName : Model.LastName;
			author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;

			_context.SaveChanges();
		}
	}

	public class UpdateAuthorModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
