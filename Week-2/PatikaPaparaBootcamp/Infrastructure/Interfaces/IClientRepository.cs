using PatikaPaparaBootcamp.Domain.Entities;
using System.Collections.Generic;

namespace PatikaPaparaBootcamp.Infrastructure.Interfaces
{
	public interface IClientRepository
	{
		Client GetById(int id);
		List<Client> GetAll();
		void Add(Client client);
		void Update(Client client);
		void Delete(Client client);
	}
}
