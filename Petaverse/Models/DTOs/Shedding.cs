namespace PetaVerse.Models.DTOs
{
    public class Shedding : BaseEntity
    {
        public string           Info { get; set; } = string.Empty;
        public SheddingLevel    Level { get; set; }
    }

    public enum SheddingLevel
    {
        Heavy, Medium, Minimal, None
    }
}
