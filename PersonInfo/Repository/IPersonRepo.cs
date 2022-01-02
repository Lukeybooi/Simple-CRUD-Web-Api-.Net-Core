using PersonInfo.Models;
using System;
using System.Collections.Generic;

namespace PersonInfo.Repository
{
    public interface IPersonRepo
    {
        Person CreatePerson(Person person);
        IEnumerable<Person> GetAllPeople();
        Person GetPersonById(Guid id);
        void UpdatePerson(Person person);
        void DeletePerson(Guid id);
        void AddDummyData(short amt);
        bool SaveChanges();
    }
}
