using System.Globalization;

namespace backend.Dtos
{
    public class CityDto
    {
        public int? CityId { get; set; }

        public string CityName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsActive { get; set; }

        public int? ProvinceId { get; set; }

        public string? ProvinceName { get; set; }
    }
}
