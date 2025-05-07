using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetail;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DbOperations;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly BookStoreDbContext _context;
		private readonly IMapper _mapper;

		public AuthorController(BookStoreDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAuthors()
		{
			var query = new GetAuthorsQuery(_context, _mapper);
			var result = query.Handle();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var query = new GetAuthorDetailQuery(_context, _mapper)
			{
				AuthorId = id
			};

			var validator = new GetAuthorDetailQueryValidator();
			validator.ValidateAndThrow(query);

			var result = query.Handle();
			return Ok(result);
		}

		[HttpPost]
		public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
		{
			var command = new CreateAuthorCommand(_context)
			{
				Model = model
			};

			var validator = new CreateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
		{
			var command = new UpdateAuthorCommand(_context)
			{
				AuthorId = id,
				Model = model
			};

			var validator = new UpdateAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteAuthor(int id)
		{
			var command = new DeleteAuthorCommand(_context)
			{
				AuthorId = id
			};

			var validator = new DeleteAuthorCommandValidator();
			validator.ValidateAndThrow(command);

			command.Handle();
			return Ok();
		}
	}
}
