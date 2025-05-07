using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Tests.TestsSetup
{
	public static class Genres
	{
		public static void AddGenres(this BookStoreDbContext context)
		{
			var genre1 = new Genre { Name = "Personal Growth" };
			var genre2 = new Genre { Name = "Science Fiction" };
			var genre3 = new Genre { Name = "Romance" };

			context.Genres.AddRange(genre1, genre2, genre3);
		}
	}
}
