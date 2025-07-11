namespace ders_notlari_api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Subject { get; set; } = "";
        public string Description { get; set; } = "";
        public string FilePath { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
