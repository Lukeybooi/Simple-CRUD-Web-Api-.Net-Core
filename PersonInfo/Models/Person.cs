using PersonInfo.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonInfo.Models
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public Race Race { get; set; }
    }
}
