using System.ComponentModel.DataAnnotations;

namespace ContactAPIs.Models;

public class Contact
{
    [Key]
    public Guid? Id { get; set; }

    public string Name { get; set; }

    public int TelephoneNumber { get; set; }

    public string Email { get; set; }

    public Contact() { }

    public Contact(Guid id, string name, int telephoneNumber, string email)
    {
        Id = id; 
        Name = name; 
        TelephoneNumber = telephoneNumber;
        Email = email;
    }
}
