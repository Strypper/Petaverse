using System;

namespace PetaVerse.Models.DTOs
{
    public class Temperament : BaseEntity
    {
        public string   Info    { get; set; } = String.Empty;
        public int      Level   { get; set; }
    }
}
