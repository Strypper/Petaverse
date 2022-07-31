using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PetaVerse.Models.DTOs
{
    public class User : UserPrincipal
    {
        public DateTime     CreatedAt                { get; set; } = DateTime.UtcNow;
        public bool         IsActive                 { get; set; }
        public bool         IsDeleted                { get; set; } = false;
        public string?      CoverImageUrl            { get; set; } = String.Empty;
        public string?      PetaverseProfileImageUrl { get; set; } = String.Empty;

        public ICollection<Animal> Pets { get; set; } = new ObservableCollection<Animal>();
    }
    
    public class TotechsIdentityUser
    {
        public string AccessToken { get; set; }
        public UserPrincipal UserInfo { get; set; }
    }

    public class UserPrincipal : BaseEntity
    {
        public string Guid { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfilePicUrl { get; set; }
    }

    public class LoginModel 
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }


    public static class UserExtensions
    {
        public static void FillPricipalUserInfo(this User user, UserPrincipal principalInfo)
        {
            user.Guid = principalInfo.Guid;
            user.FirstName = principalInfo.FirstName;
            user.LastName = principalInfo.LastName;
            user.DateOfBirth = principalInfo.DateOfBirth;
            user.PhoneNumber = principalInfo.PhoneNumber;
            user.Email = principalInfo.Email;
            user.Gender = principalInfo.Gender;
            user.ProfilePicUrl = principalInfo.ProfilePicUrl;
        }
    }
}
