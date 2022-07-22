using System;
using System.Collections.Generic;

namespace PetaVerse.Models.DTOs
{
    public class User : UserPrincipal
    {
        public DateTime     CreatedAt           { get; set; } = DateTime.UtcNow;
        public bool?        IsActive            { get; set; }
        public bool         IsDeleted           { get; set; } = false;

        public virtual ICollection<Animal> Pets { get; set; } = new HashSet<Animal>();
    }
    
    public class PetvaserveUser
    {
        public string accessToken { get; set; }
        public UserPrincipal userInfo { get; set; }
    }

    public class UserPrincipal : BaseEntity
    {
        public string guid { get; set; } = string.Empty;
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string fullName => firstName + lastName;
        public string email { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public bool? gender { get; set; }
        public DateTime? dateOfBirth { get; set; }
        public string? profilePicUrl { get; set; }
    }

    public class LoginModel 
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
