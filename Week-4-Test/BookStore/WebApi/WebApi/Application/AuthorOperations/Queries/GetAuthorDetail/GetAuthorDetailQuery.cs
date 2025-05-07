using AutoMapper;
using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
	public class GetAuthorDetailQuery
	{
		public int AuthorId { get; set; }
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public AuthorDetailViewModel Handle()
		{
			var author = _context.Authors.FirstOrDefault(x => x.Id == AuthorId);
			if (author == null)
				throw new InvalidOperationException("Yazar bulunamadı.");

			return _mapper.Map<AuthorDetailViewModel>(author);
		}
	}

	public class AuthorDetailViewModel
	{
		public string FullName { get; set; }
		public string BirthDate { get; set; }
	}
}
