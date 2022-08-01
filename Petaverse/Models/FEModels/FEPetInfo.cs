using System;
using Windows.Storage;

namespace Petaverse.Models.FEModels
{
    public class FEPetInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string PetColor { get; set; } = string.Empty;
        public StorageFile PetAvatar { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int BreedId { get; set; }
        public int SpeciesId { get; set; }
        public string OwnerGuids { get; set; }
    }
}
