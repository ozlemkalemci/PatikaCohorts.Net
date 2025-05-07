using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly BookStoreDbContext _context;

		public BookController(BookStoreDbContext context)
		{
			_context = context;
		}

		//	private static List<Book> BookList = new List<Book>()
		//	{
		//		new Book()
		//		{
		//			Id = 1,
		//			GenreId = 1,
		//			PageCount = 200,
		//			PublishDate = new System.DateTime(2001,06,12),
		//			Title = "Lean Startup",
		//		},
		//		new Book()
		//		{
		//			Id = 2,
		//			GenreId = 2,
		//			PageCount = 250,
		//			PublishDate = new System.DateTime(2002,06,12),
		//			Title = "Herland",
		//		},
		//		new Book()
		//		{
		//			Id = 3,
		//			GenreId = 3,
		//			PageCount = 370,
		//			PublishDate = new System.DateTime(2003,06,12),
		//			Title = "Dune",
		//		},
		//	};


		[HttpGet]
		//public List<Book> GetBooks()
		public IActionResult GetBooks()
		{
			// var books = BookList.OrderBy(x => x.Id).ToList<Book>();

			//var books = _context.Books.OrderBy(x => x.Id).ToList<Book>();
			//return books;

			GetBooksQuery query = new GetBooksQuery(_context);
			var result = query.Handle();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			//var books = BookList.Where(x => x.Id == id).FirstOrDefault();


			//var books = _context.Books.Where(x => x.Id == id).FirstOrDefault();
			//return books;
			BooksDetailViewModel result;
			try
			{
				GetBookDetailQuery query = new GetBookDetailQuery(_context);
				query.BookId = id;
				result = query.Handle();

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			return Ok(result);
		}

		[HttpPost]
		public IActionResult AddBook([FromBody] CreateBookModel newBook)
		{
			//var book = BookList.FirstOrDefault(x => x.Title == newBook.Title);

			//var book = _context.Books.FirstOrDefault(x => x.Title == newBook.Title);
			//if (book != null)
			//	return BadRequest(book.Title);

			//var result = new Book()
			//{
			//	PageCount = newBook.PageCount,
			//	GenreId = newBook.GenreId,
			//	Title = newBook.Title,
			//	PublishDate = Convert.ToDateTime(newBook.PublishDate),
			//};

			//_context.Books.Add(result);
			//_context.SaveChanges();

			CreateBookCommand command = new CreateBookCommand(_context);
			command.Model = newBook;

			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updateBook)
		{
			//var book = BookList.FirstOrDefault(x => x.Id == id);

			//var book = _context.Books.FirstOrDefault(x => x.Id == id);
			//if (book == null)
			//	return BadRequest();

			//book.PublishDate = updateBook.PublishDate != default ? updateBook.PublishDate : book.PublishDate;
			//book.Title = updateBook.Title != default ? updateBook.Title : book.Title;
			//book.GenreId = updateBook.GenreId != default ? updateBook.GenreId : book.GenreId;
			//book.PageCount = updateBook.PageCount != default ? updateBook.PageCount : book.PageCount;
			//_context.SaveChanges();
			try
			{
				UpdateBookCommand command = new UpdateBookCommand(_context);
				command.BookId = id;
				command.Model = updateBook;
				command.Handle();
			}
			catch (Exception ex )
			{

				return BadRequest(ex.Message);
			}
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBook(int id)
		{
			try
			{
				DeleteBookCommand command = new DeleteBookCommand(_context);
				command.BookId = id;
				command.Handle();
			}
			catch (Exception ex)
			{

				return BadRequest(ex.Message);
			}
			
			return Ok();
		}
	}
}
