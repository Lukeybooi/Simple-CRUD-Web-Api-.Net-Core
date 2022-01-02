using PersonInfo.Enums;
using PersonInfo.Models;
using System;

namespace PersonInfo.Helpers
{
    public static class Generate
    {
        private readonly static string MaleNames = "male_names.json";
        private readonly static string FemaleNames = "female_names.json";
        private readonly static string SurNames = "last_names.json";
        public static Person[] GetPeople(int l)
        {
            Person[] people = new Person[l];

            for (int i = 0; i < l; i++)
            {
                people[i] = GetPerson();
            }

            return people;
        }

        public static Person GetPerson()
        {
            Random rnd = new Random();
            string temp = rnd.Next(2) == ((int)Gender.Male) ? MaleNames : FemaleNames;
            string[] names = ReadFileToJSON.ReadFile(temp);
            string[] surnames = ReadFileToJSON.ReadFile(SurNames);
            DateTime dob = GetRandomDateRange(new DateTime(1995, 1, 1), DateTime.Today);
            Gender gender = temp == MaleNames ? Gender.Male : Gender.Female;
            Race race = (Race)rnd.Next(1, 7);

            return new Person
            {
                Id = Guid.NewGuid(),
                FirstName = names[rnd.Next(names.Length)],
                LastName = surnames[rnd.Next(surnames.Length)],
                Dob = dob,
                Gender = gender,
                Race = race
            };
        }

        public static DateTime GetRandomDateRange(DateTime start, DateTime end)
        {
            Random gen = new Random();

            int range = (end - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
