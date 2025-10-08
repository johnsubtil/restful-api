using RestAPI.Model;

namespace RestAPI.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        Person IPersonService.Create(Person person)
        {
            return person;
        }

        void IPersonService.Delete(int id)
        {
        }

        List<Person> IPersonService.FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                var p = new Person
                {
                    Id = i + 1,
                    Nome = $"Teste_{i}",
                    Endereco = "Teste",
                    Genero = "Masculino"
                };

                persons.Add(p);
            }

            return persons;
        }

        Person IPersonService.FindById(int id)
        {
            return new Person
            {
                Id = 1,
                Nome = "Teste",
                Endereco = "Teste",
                Genero = "Masculino"
            };
        }

        Person IPersonService.Update(Person person)
        {
            return person;
        }
    }
}
