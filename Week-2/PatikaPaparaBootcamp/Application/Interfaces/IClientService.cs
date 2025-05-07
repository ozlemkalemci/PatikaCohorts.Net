using PatikaPaparaBootcamp.Domain.Entities;
using System.Collections.Generic;

namespace PatikaPaparaBootcamp.Application.Interfaces
{
	public interface IClientService
	{
		Client GetById(int id);
		List<Client> GetAll();
		List<Client> List(string? name, string? sortBy);
		Client Create(Client client);
		Client Update(int id, Client updated);
		Client PatchPhone(int id, string phone);
		void Delete(int id);
	}
}
