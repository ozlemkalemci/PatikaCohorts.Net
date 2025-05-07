using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Tests.TestsSetup
{
	public static class Books
	{
		public static void AddBooks(this BookStoreDbContext context)
		{
			context.Books.AddRange(
				new Book
				{
					Title = "Lean Startup",
					GenreId = 1, // Personal Growth
					AuthorId = 1,
					PageCount = 250,
					PublishDate = new DateTime(2022, 06, 02)
				},
				new Book
				{
					Title = "Herland",
					GenreId = 2, // Science Fiction
					AuthorId = 2,
					PageCount = 300,
					PublishDate = new DateTime(2000, 06, 15)
				},
				new Book
				{
					Title = "Dune",
					GenreId = 2, // Science Fiction
					AuthorId = 3,
					PageCount = 370,
					PublishDate = new DateTime(2001, 07, 02)
				});
		}
	}
}
