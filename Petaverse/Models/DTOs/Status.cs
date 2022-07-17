namespace PetaVerse.Models.DTOs
{
    public class Status : BaseEntity
    {
        public string   Toppic      { get; set; } = string.Empty;
        public string   Title       { get; set; } = string.Empty;   
        public string?  Content     { get; set; }
        public int?     Likes       { get; set; }


        public User?    User    { get; set; }
    }
}
