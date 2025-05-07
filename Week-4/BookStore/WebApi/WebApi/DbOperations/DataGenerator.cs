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
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
			{
				// Eğer veri varsa, çık
				if (context.Books.Any() || context.Genres.Any())
				{
					return;
				}

				// 📌 Önce Genre'ları ekleyelim
				context.Genres.AddRange(
					new Genre { Name = "Personal Growth" },
					new Genre { Name = "Science Fiction" },
					new Genre { Name = "Romance" }
				);

				context.SaveChanges(); // Genre'ları kaydet

				// 📌 Şimdi Book'ları ekleyelim
				context.Books.AddRange(
					new Book
					{
						Title = "Lean Startup",
						GenreId = 1, // Personal Growth
						PageCount = 250,
						PublishDate = new DateTime(2022, 06, 02)
					},
					new Book
					{
						Title = "Herland",
						GenreId = 2, // Science Fiction
						PageCount = 300,
						PublishDate = new DateTime(2000, 06, 15)
					},
					new Book
					{
						Title = "Dune",
						GenreId = 2, // Science Fiction
						PageCount = 370,
						PublishDate = new DateTime(2001, 07, 02)
					}
				);

				context.SaveChanges();
			}
		}
	}
}
