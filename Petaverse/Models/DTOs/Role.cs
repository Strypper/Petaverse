using System.Collections.Generic;

namespace PetaVerse.Models.DTOs
{
    public class Role : BaseEntity
    {
        public string   Name    { get; set; } = string.Empty;
        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}