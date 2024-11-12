namespace WebApp.Models.Services;

public class MemoryContactService:IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {1,new ContactModel(){Id = 1,FirstName = "Lukas",LastName = "Janus",Email = "LukasJanus@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,03,18), PhoneNumber = "607 758 331"}},
        {2,new ContactModel(){Id = 2,FirstName = "Pawel",LastName = "Wrona",Email = "PawelWrona@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,07,18), PhoneNumber = "111 222 333"}},
        {3,new ContactModel(){Id = 3,FirstName = "Kacper",LastName = "Wojas",Email = "KacperWojas@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2005,03,18), PhoneNumber = "412 123 123"}}
    };

    private int _currentId = 3;
    
    public void Add(ContactModel cm)
    {
        cm.Id = ++_currentId;
        _contacts.Add(cm.Id,cm);
    }

    public void Update(ContactModel cm)
    {
        if (_contacts.ContainsKey(cm.Id))
        {
            _contacts[cm.Id] = cm;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> GetOrganizations()
    {
        throw new NotImplementedException();
    }
}