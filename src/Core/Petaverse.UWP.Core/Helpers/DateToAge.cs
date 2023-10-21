namespace Petaverse.UWP.Core;

public static class DateToAge
{
    public static Int32 GetAgeSupportNullDateTime(this DateTime? dateOfBirth)
    {
        var today = DateTime.UtcNow;
        var dateOfBirthValue = dateOfBirth ?? today;
        var age = today.Year - dateOfBirthValue.Year;
        return age;
    }

    public static Int32 GetAge(this DateTime dateOfBirth)
    {
        var today = DateTime.UtcNow;
        var dateOfBirthValue = today;
        var age = today.Year - dateOfBirthValue.Year;
        return age;
    }
}
