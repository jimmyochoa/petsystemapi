namespace backend.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Direction { get; set; } = null!;
        public int ProvinceId { get; set; }
        public bool IsActive { get; set; }
    }
}