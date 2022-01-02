using PersonInfo.Helpers;
using PersonInfo.Models;
using PersonInfo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo.Data
{
    public class SqlPerson : IPersonRepo
    {
        private readonly PersonContext _context;

        public SqlPerson(PersonContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            _context.PersonTbl.Add(person);
            return person;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _context.PersonTbl.ToList();
        }

        public Person GetPersonById(Guid id)
        {
            return _context.PersonTbl.FirstOrDefault(p => p.Id == id);
        }

        public void UpdatePerson(Person person)
        {
            _context.PersonTbl.Update(person);
        }

        public void DeletePerson(Guid id)
        {
            var person = GetPersonById(id);
            if (person != null) { _context.PersonTbl.Remove(person); }
        }

        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() >= 0;
            }
            catch (Exception) { return false; }
        }

        public void AddDummyData(short value)
        {
            _context.PersonTbl.AddRange(Generate.GetPeople(value));
        }
    }
}
