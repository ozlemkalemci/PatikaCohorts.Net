using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
	public class GetAuthorsQuery
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public List<AuthorViewModel> Handle()
		{
			var authors = _context.Authors.OrderBy(x => x.Id).ToList();
			return _mapper.Map<List<AuthorViewModel>>(authors);
		}
	}

	public class AuthorViewModel
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string BirthDate { get; set; }
	}
}
