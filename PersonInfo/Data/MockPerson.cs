using PersonInfo.Helpers;
using PersonInfo.Models;
using PersonInfo.Repository;
using System;
using System.Collections.Generic;

namespace PersonInfo.Data
{
    public class MockPerson : IPersonRepo
    {
        private List<Person> people { get; set; } = new List<Person>(Generate.GetPeople(5));
        private bool allowSave = false;

        public MockPerson() { }

        public Person CreatePerson(Person person)
        {
            var newPerson = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Dob = person.Dob,
                Gender = person.Gender,
                Race = person.Race
            };

            people.Add(newPerson);
            allowSave = true;

            return newPerson;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return people;
        }

        public Person GetPersonById(Guid id)
        {
            return people.Find(p => p.Id == id);
        }

        public void UpdatePerson(Person person)
        {
            var personId = person.Id;

            allowSave = false;

            if (people.Exists(p => p.Id == person.Id))
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Id == personId)
                    {
                        people.RemoveAt(i);
                        people.Insert(i, person);
                        allowSave = true;
                        break;
                    }
                }
            }
        }

        public void DeletePerson(Guid id)
        {
            allowSave = false;

            if (people.Exists(p => p.Id == id))
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Id == id)
                    {
                        people.RemoveAt(i);
                        allowSave = true;
                        break;
                    }
                }
            }
        }

        public bool SaveChanges()
        {
            return allowSave;
        }

        public void AddDummyData(short value)
        {
            allowSave = false;

            people.AddRange(Generate.GetPeople(value));

            allowSave = value > 0;
        }
    }
}
