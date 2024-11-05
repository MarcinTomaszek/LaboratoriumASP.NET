namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity toEntity(ContactModel arg)
    {
        return new ContactEntity()
        {
            Id = arg.Id,
            BirthDate = arg.BirthDate,
            Category = arg.Category,
            Email = arg.Email,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber
        };
    }

    public static ContactModel fromEntity(ContactEntity arg)
    {
        return new ContactModel()
        {
            Id = arg.Id,
            BirthDate = arg.BirthDate,
            Category = arg.Category,
            Email = arg.Email,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber
        };
    }
}