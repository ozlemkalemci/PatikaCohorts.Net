using Microsoft.AspNetCore.Mvc;
using PatikaPaparaBootcamp.Application.Interfaces;
using PatikaPaparaBootcamp.Domain.Entities;

namespace PatikaPaparaBootcamp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _service;

		public ClientController(IClientService service)
		{
			_service = service;
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var client = _service.GetById(id);
			if (client == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			return Ok(new { Status = 200, Data = client });
		}

		[HttpGet("list")]
		public IActionResult List([FromQuery] string? name, [FromQuery] string? sortBy = "Id")
		{
			var result = _service.List(name, sortBy);
			return Ok(new { Status = 200, Data = result });
		}

		[HttpGet("all")]
		public IActionResult GetAll()
		{
			return Ok(new { Status = 200, Data = _service.GetAll() });
		}

		[HttpPost]
		public IActionResult Create([FromBody] Client client)
		{
			var created = _service.Create(client);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, new { Status = 201, Data = created });
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Client updated)
		{
			var result = _service.Update(id, updated);
			if (result == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			return Ok(new { Status = 200, Data = result });
		}

		[HttpPatch("{id}")]
		public IActionResult PatchPhone(int id, [FromQuery] string phone)
		{
			var result = _service.PatchPhone(id, phone);
			if (result == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			return Ok(new { Status = 200, Data = result });
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_service.Delete(id);
			return NoContent();
		}
	}
}
