using PatikaPaparaBootcamp.Application.Interfaces;
using PatikaPaparaBootcamp.Domain.Entities;
using PatikaPaparaBootcamp.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PatikaPaparaBootcamp.Application.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repository;

		public ClientService(IClientRepository repository)
		{
			_repository = repository;
		}

		public Client GetById(int id) => _repository.GetById(id);

		public List<Client> GetAll() => _repository.GetAll();

		public List<Client> List(string? name, string? sortBy)
		{
			var query = _repository.GetAll().AsQueryable();

			if (!string.IsNullOrWhiteSpace(name))
				query = query.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

			return sortBy?.ToLower() switch
			{
				"name" => query.OrderBy(c => c.Name).ToList(),
				"age" => query.OrderBy(c => c.Age).ToList(),
				_ => query.OrderBy(c => c.Id).ToList()
			};
		}

		public Client Create(Client client)
		{
			_repository.Add(client);
			return client;
		}

		public Client Update(int id, Client updated)
		{
			var client = _repository.GetById(id);
			if (client == null) return null;

			updated.Id = id;
			_repository.Update(updated);
			return updated;
		}

		public Client PatchPhone(int id, string phone)
		{
			var client = _repository.GetById(id);
			if (client == null) return null;

			client.Phone = phone;
			_repository.Update(client);
			return client;
		}

		public void Delete(int id)
		{
			var client = _repository.GetById(id);
			if (client != null)
				_repository.Delete(client);
		}
	}
}
