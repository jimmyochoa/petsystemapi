namespace backend.Dtos
{
    public class PetDto
    {
        public int PetId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int PetTypeId { get; set; }
        public bool IsActive { get; set; }
    }
}