using PersonInfo.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfo.Dtos
{
    public class PersonCreateDto
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime? Dob { get; set; }
        [Required]
        public Gender? Gender { get; set; }
        public Race Race { get; set; }
    }
}
