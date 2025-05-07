using PatikaPaparaBootcamp.Domain.Entities;
using PatikaPaparaBootcamp.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PatikaPaparaBootcamp.Infrastructure.Repositories
{
	public class InMemoryClientRepository : IClientRepository
	{
		private readonly List<Client> _clients = new()
		{
			new Client { Id = 1, Name = "Özlem", SurName = "Kalemci", Age = 25, Email = "ozlem@example.com", Phone = "5551234567", Address = "Eskişehir" },
			new Client { Id = 2, Name = "Berkay", SurName = "Sönmez", Age = 30, Email = "berkay@example.com", Phone = "5557654321", Address = "Eskişehir" },
		};

		public List<Client> GetAll() => _clients;

		public Client GetById(int id) => _clients.FirstOrDefault(c => c.Id == id);

		public void Add(Client client)
		{
			client.Id = _clients.Max(c => c.Id) + 1;
			_clients.Add(client);
		}

		public void Update(Client client)
		{
			var existing = GetById(client.Id);
			if (existing != null)
			{
				existing.Name = client.Name;
				existing.SurName = client.SurName;
				existing.Age = client.Age;
				existing.Email = client.Email;
				existing.Phone = client.Phone;
				existing.Address = client.Address;
			}
		}

		public void Delete(Client client)
		{
			_clients.Remove(client);
		}
	}
}
