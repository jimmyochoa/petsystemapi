namespace backend.Dtos
{
    public class CareTaskDto
    {
        public int CareTaskId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
