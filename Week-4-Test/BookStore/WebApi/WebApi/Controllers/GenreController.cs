using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GenreController : ControllerBase
	{
		private readonly IBookStoreDbContext _context;
		private readonly IMapper _mapper;

		public GenreController(IBookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetGenres()
		{
			var query = new GetGenresQuery(_context, _mapper);
			var result = query.Handle();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var query = new GetGenreDetailQuery(_context, _mapper);
			query.GenreId = id;

			var validator = new GetGenreDetailQueryValidator();
			validator.ValidateAndThrow(query);

			var result = query.Handle();
			return Ok(result);
		}

		[HttpPost]
		public IActionResult AddGenre([FromBody] CreateGenreModel model)
		{
			var command = new CreateGenreCommand(_context);
			command.Model = model;

			var validator = new CreateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
		{
			var command = new UpdateGenreCommand(_context);
			command.GenreId = id;
			command.Model = model;

			var validator = new UpdateGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteGenre(int id)
		{
			var command = new DeleteGenreCommand(_context);
			command.GenreId = id;

			var validator = new DeleteGenreCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}
	}
}
