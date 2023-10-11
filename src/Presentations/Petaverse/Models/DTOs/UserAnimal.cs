namespace Petaverse.Models.DTOs
{
    public class UserAnimal : BaseEntity
    {
        public int   UserId      { get; set; }
        public int   AnimalId    { get; set; }

        public Animal  Animal  { get; set; }
        public User    User    { get; set; }
    }
}
