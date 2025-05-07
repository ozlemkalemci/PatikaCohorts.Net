﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace WebApi.DbOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
			{
				if (context.Books.Any())
				{
					return;
				}

				context.Books.AddRange(
					new Book
					{
						GenreId = 1,
						PageCount = 250,
						PublishDate = new DateTime(2022, 06, 02),
						Title = "Lean Startup",
					},
					new Book
					{
						GenreId = 2,
						PageCount = 300,
						PublishDate = new DateTime(2000, 06, 15),
						Title = "HerLand",
					},
					new Book
					{
						GenreId = 3,
						PageCount = 370,
						PublishDate = new DateTime(2001, 07, 02),
						Title = "Dune",
					});

				context.SaveChanges();
			}
		}
	}
}