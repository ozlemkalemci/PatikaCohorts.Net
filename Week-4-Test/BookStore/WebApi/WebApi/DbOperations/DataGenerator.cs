using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApi.Entities;

namespace WebApi.DbOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new BookStoreDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
			{
				if (context.Books.Any() || context.Genres.Any() || context.Authors.Any())
				{
					return; // Zaten veri varsa ekleme
				}

				// 📌 Genre'lar
				var genre1 = new Genre { Name = "Personal Growth" };
				var genre2 = new Genre { Name = "Science Fiction" };
				var genre3 = new Genre { Name = "Romance" };

				context.Genres.AddRange(genre1, genre2, genre3);
				context.SaveChanges();

				// 📌 Author'lar
				var author1 = new Author
				{
					FirstName = "Eric",
					LastName = "Ries",
					BirthDate = new DateTime(1978, 9, 22)
				};

				var author2 = new Author
				{
					FirstName = "Charlotte",
					LastName = "Perkins Gilman",
					BirthDate = new DateTime(1860, 7, 3)
				};

				var author3 = new Author
				{
					FirstName = "Frank",
					LastName = "Herbert",
					BirthDate = new DateTime(1920, 10, 8)
				};

				context.Authors.AddRange(author1, author2, author3);
				context.SaveChanges();

				// 📌 Book'lar (AuthorId ilişkili!)
				context.Books.AddRange(
					new Book
					{
						Title = "Lean Startup",
						GenreId = genre1.Id,
						AuthorId = author1.Id,
						PageCount = 250,
						PublishDate = new DateTime(2022, 6, 2)
					},
					new Book
					{
						Title = "Herland",
						GenreId = genre2.Id,
						AuthorId = author2.Id,
						PageCount = 300,
						PublishDate = new DateTime(2000, 6, 15)
					},
					new Book
					{
						Title = "Dune",
						GenreId = genre2.Id,
						AuthorId = author3.Id,
						PageCount = 370,
						PublishDate = new DateTime(2001, 7, 2)
					}
				);

				context.SaveChanges();
			}
		}
	}
}
