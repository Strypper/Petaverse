using System;

namespace Petaverse.UWP.Contracts;

public class RegisteringModel 
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string? CityId { get; set; }
    public string? RegionId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public bool Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string IdentityCardId { get; set; }
};
