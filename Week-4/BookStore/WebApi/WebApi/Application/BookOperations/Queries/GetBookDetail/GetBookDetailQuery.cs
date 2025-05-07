using AutoMapper;
using System;
using System.Linq;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.Application.BookOperations.Queries.GetBookDetail
{
	public class GetBookDetailQuery
	{
		private readonly BookStoreDbContext _context;
		public int BookId { get; set; }
		private readonly IMapper _mapper;
		public GetBookDetailQuery(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public BooksDetailViewModel Handle()
		{
			var book = _context.Books.Where(x => x.Id == BookId).FirstOrDefault();
			if (book == null)
				throw new InvalidOperationException("Kitap bulunamadı");

			BooksDetailViewModel vm = _mapper.Map<BooksDetailViewModel>(book);
			return vm;
		}

		public class BooksDetailViewModel
		{ 
			public string Title { get; set; }
			public string Genre { get; set; }
			public int PageCount { get; set; }
			public string PublishDate { get; set; }
		}
	}
}
