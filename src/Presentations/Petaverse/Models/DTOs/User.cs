using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Petaverse.Models.DTOs
{
    public class User : UserPrincipal
    {
        public DateTime     CreatedAt                { get; set; } = DateTime.UtcNow;
        public bool         IsActive                 { get; set; }
        public bool         IsDeleted                { get; set; } = false;
        public string?      CoverImageUrl            { get; set; } = string.Empty;
        public string?      TeamLogo                 { get; set; } = string.Empty;
        public string?      PetaverseProfileImageUrl { get; set; } = string.Empty;

        public ICollection<Animal> Pets { get; set; } = new ObservableCollection<Animal>();

        //Fake Data
        public int NumberOfCats { get; set; }
        public int NumberOfDogs { get; set; }
        public int Foster { get; set; }
        public int Hero { get; set; }
        public string City { get; set; }
        public string DummyWord { get; set; }

    }
    
    public class TotechsIdentityUser
    {
        public string AccessToken { get; set; }
        public UserPrincipal UserInfo { get; set; }
    }

    public class UserPrincipal : BaseEntity
    {
        public string    Guid          { get; set; } = string.Empty;
        public string    UserName      { get; set; } = string.Empty;
        public string    FirstName     { get; set; } = string.Empty;
        public string    MiddleName    { get; set; } = string.Empty;
        public string    LastName      { get; set; } = string.Empty;
        public string    FullName => FirstName + " " + LastName;
        public string    Email         { get; set; } = string.Empty;
        public string    PhoneNumber   { get; set; } = string.Empty;
        public bool?     Gender        { get; set; }
        public DateTime? DateOfBirth   { get; set; }
        public string?   ProfilePicUrl { get; set; }
    }

    public class RegisterModel : UserPrincipal
    {
        public string Password { get; set; }
        public string RoleGuid { get; set; }
    }

    public class LoginModel 
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }

    public class CreatePetaverseUserModel
    {
        public string Guid { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? CoverImageUrl { get; set; } = String.Empty;
        public string PetaverseProfileUrl { get; set; }
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
