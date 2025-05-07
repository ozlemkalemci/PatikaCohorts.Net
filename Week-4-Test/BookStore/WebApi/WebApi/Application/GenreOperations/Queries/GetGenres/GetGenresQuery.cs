using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
	public class GetGenresQuery
	{
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GetGenresQuery(IBookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public List<GenreViewModel> Handle()
		{
			var genres = _context.Genres
								 .Where(g => g.IsActive)
								 .OrderBy(g => g.Id)
								 .ToList();

			return _mapper.Map<List<GenreViewModel>>(genres);
		}
	}

	public class GenreViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
