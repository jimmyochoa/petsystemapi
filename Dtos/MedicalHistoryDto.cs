namespace backend.Dtos
{

    public class MedicalHistoryDto
    {
        public int MedicalHistoryId { get; set; }
        public int PetId { get; set; }
        public int ResourceId { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
