using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestAPI.Model;
using RestAPI.Model.Context;
using System;

namespace RestAPI.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context) 
        {
            _context = context;
        }

        Person IPersonService.Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        void IPersonService.Delete(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);

            if (person != null)
            {
                try
                {
                    _context.Remove(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        List<Person> IPersonService.FindAll()
        {
            return _context.Persons.ToList();
        }

        Person? IPersonService.FindById(int id)
        {
            var person = _context.Persons.SingleOrDefault(p => p.Id == id);
            
            if (person != null)
                return person;

            return null;
        }

        Person? IPersonService.Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            try
            {
                _context.Update(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return person;
        }

        private bool Exists(int id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
