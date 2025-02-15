namespace backend.Dtos
{
    public class ResourceDto
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}