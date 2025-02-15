using backend.Dtos;

namespace backend.Interfaces
{

    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClients();
        Task<ClientDto?> GetClientById(int id);
        Task<bool> AddClient(ClientDto clientDto);
        Task<bool> UpdateClient(ClientDto clientDto);
        Task<bool> DeleteClient(int id);
    }
}
