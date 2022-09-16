using System.Collections.Generic;

namespace Petaverse.Models.FEModels
{
    public class CreatePetShortDTO
    {
        public string Title { get; set; } = string.Empty;
        public int RepresentativePetId { get; set; }
        public ICollection<int> PetIds { get; set; } = new HashSet<int>();
    }
}
