namespace backend.Dtos
{
    public class ProvinceDto
    {
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
