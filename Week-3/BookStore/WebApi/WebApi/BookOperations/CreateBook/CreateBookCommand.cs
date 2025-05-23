﻿using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.CreateBook
{
	public class CreateBookCommand
	{
		public CreateBookModel Model { get; set; }
		private readonly BookStoreDbContext _context;
		public CreateBookCommand(BookStoreDbContext context)
		{
			_context = context;
		}

		public void Handle()
		{
			var book = _context.Books.FirstOrDefault(x => x.Title == Model.Title);
			if (book != null)
				throw new InvalidOperationException("Kitap zaten mevcut");

			book = new Book();

			book.PageCount = Model.PageCount;
			book.GenreId = Model.GenreId;
			book.Title = Model.Title;
			book.PublishDate = Convert.ToDateTime(Model.PublishDate);


			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public class CreateBookModel
		{
			public string Title { get; set; }
			public int GenreId { get; set; }
			public int PageCount { get; set; }
			public DateTime PublishDate { get; set; }
		}
	}
}
