using Microsoft.AspNetCore.Mvc;
using PatikaPaparaBootcamp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PatikaPaparaBootcamp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ClientController : ControllerBase
	{
		private static List<Client> _clients = new List<Client>
	{
		new Client { Id = 1, Name = "Özlem", SurName = "Kalemci", Age = 25, Email = "ozlem@example.com", Phone = "5551234567", Address = "Eskişehir" },
		new Client { Id = 2, Name = "Berkay", SurName = "Sönmez", Age = 30, Email = "berkay@example.com", Phone = "5557654321", Address = "Eskişehir" },
	};

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var client = _clients.FirstOrDefault(c => c.Id == id);
			if (client == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			return Ok(new { Status = 200, Data = client });
		}

		[HttpGet("list")]
		public IActionResult List([FromQuery] string? name, [FromQuery] string? sortBy = "Id")
		{
			var query = _clients.AsQueryable();

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(c => c.Name.Contains(name));

			query = sortBy?.ToLower() switch
			{
				"name" => query.OrderBy(c => c.Name),
				"age" => query.OrderBy(c => c.Age),
				_ => query.OrderBy(c => c.Id)
			};

			return Ok(new { Status = 200, Data = query.ToList() });
		}

		[HttpGet("all")]
		public IActionResult GetAll()
		{
			return Ok(new { Status = 200, Data = _clients });
		}

		[HttpPost]
		public IActionResult Create([FromBody] Client client)
		{
			client.Id = _clients.Count + 1;
			_clients.Add(client);
			return CreatedAtAction(nameof(GetById), new { id = client.Id }, new { Status = 201, Data = client });
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, [FromBody] Client updated)
		{
			var client = _clients.FirstOrDefault(c => c.Id == id);
			if (client == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			client.Name = updated.Name;
			client.SurName = updated.SurName;
			client.Age = updated.Age;
			client.Email = updated.Email;
			client.Phone = updated.Phone;
			client.Address = updated.Address;

			return Ok(new { Status = 200, Data = client });
		}

		[HttpPatch("{id}")]
		public IActionResult PatchPhone(int id, [FromQuery] string phone)
		{
			var client = _clients.FirstOrDefault(c => c.Id == id);
			if (client == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			client.Phone = phone;
			return Ok(new { Status = 200, Data = client });
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var client = _clients.FirstOrDefault(c => c.Id == id);
			if (client == null)
				return NotFound(new { Status = 404, Error = "Client not found" });

			_clients.Remove(client);
			return NoContent();
		}
	}
}