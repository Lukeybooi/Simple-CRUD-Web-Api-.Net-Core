using PersonInfo.Dtos;
using PersonInfo.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonInfo.Helpers
{
    public static class ManualMapping
    {
        public static PersonReadDto MapReadPerson(Person person)
        {
            if (person == null) { return null; };

            return new PersonReadDto
            {
                Id = person.Id,
                FirstName = person?.FirstName,
                LastName = person?.LastName,
                Age = Utils.CalculateAge(person.Dob),
                Gender = person?.Gender.ToString(),
                Race = person?.Race.ToString()
            };
        }

        public static IEnumerable<PersonReadDto> MapReadPerson(IEnumerable<Person> person)
        {
            List<Person> temp = person.ToList();
            List<PersonReadDto> list = new List<PersonReadDto>();

            for (int i = 0; i < temp.Count; i++)
            {
                list.Add(MapReadPerson(temp[i]));
            }

            return list;
        }
    }
}
