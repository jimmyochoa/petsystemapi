using backend.Dtos;
using backend.Models;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services
{
    public class ClientService : IClientService
    {
        private readonly PetSystemContext _petSystemContext;

        public ClientService(PetSystemContext petSystemContext)
        {
            _petSystemContext = petSystemContext;
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            return await _petSystemContext.Clients
                .Where(c => c.IsActive)
                .Select(c => new ClientDto
                {
                    ClientId = c.ClientId,
                    ClientName = c.ClientName,
                    Email = c.Email,
                    Phone = c.Phone,
                    Direction = c.Direction,
                    CityId = c.CityId,
                    IsActive = c.IsActive
                })
                .ToListAsync();
        }

        public async Task<ClientDto?> GetClientById(int id)
        {
            var client = await _petSystemContext.Clients
                .Where(c => c.ClientId == id && c.IsActive)
                .FirstOrDefaultAsync();

            if (client == null)
                return null;

            return new ClientDto
            {
                ClientId = client.ClientId,
                ClientName = client.ClientName,
                Email = client.Email,
                Phone = client.Phone,
                Direction = client.Direction,
                CityId = client.CityId,
                IsActive = client.IsActive
            };
        }

        public async Task<bool> AddClient(ClientDto clientDto)
        {
            var newClient = new Client
            {
                ClientName = clientDto.ClientName,
                Email = clientDto.Email,
                Phone = clientDto.Phone,
                Direction = clientDto.Direction,
                CityId = clientDto.CityId,
                IsActive = true
            };

            _petSystemContext.Clients.Add(newClient);
            await _petSystemContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateClient(ClientDto clientDto)
        {
            var client = await _petSystemContext.Clients.FindAsync(clientDto.ClientId);
            if (client == null || !client.IsActive)
                return false;

            client.ClientName = clientDto.ClientName;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone;
            client.Direction = clientDto.Direction;
            client.CityId = clientDto.CityId;

            await _petSystemContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _petSystemContext.Clients.FindAsync(id);
            if (client == null || !client.IsActive)
                return false;

            client.IsActive = false;
            await _petSystemContext.SaveChangesAsync();

            return true;
        }
    }
}
