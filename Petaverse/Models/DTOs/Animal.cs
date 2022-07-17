
using System.Collections.Generic;

namespace PetaVerse.Models.DTOs
{
    public class Animal : BaseEntity
    {
        public string  Name        { get; set; } = string.Empty;
        public string  Bio         { get; set; } = string.Empty;
        public string  Avatar      { get; set; } = string.Empty;
        public bool    Gender      { get; set; }
        public int     Age         { get; set; }
        public Species Species     { get; set; }
        public Breed   Breed       { get; set; }
        public virtual ICollection<UserAnimal> UserAnimals { get; set; } = new HashSet<UserAnimal>();
    }
}
