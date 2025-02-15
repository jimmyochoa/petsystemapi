namespace backend.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public int CityId { get; set; }
        public bool IsActive { get; set; }
    }
}
