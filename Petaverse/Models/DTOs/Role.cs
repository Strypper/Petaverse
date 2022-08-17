using System.Collections.Generic;

namespace Petaverse.Models.DTOs
{
    public class Role : BaseEntity
    {
        public string   Name    { get; set; } = string.Empty;
        public virtual ICollection<UserRole> UserRoles { get; } = new HashSet<UserRole>();
    }
}