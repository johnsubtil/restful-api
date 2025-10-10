using RestAPI.Model;

namespace RestAPI.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);
        Person? FindById(int id);
        Person? Update (Person person);
        List<Person> FindAll();
        void Delete(int id);
    }
}
