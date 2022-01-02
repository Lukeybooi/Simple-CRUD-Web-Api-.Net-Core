using System;

namespace PersonInfo.Dtos
{
    public class PersonReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
    }
}
