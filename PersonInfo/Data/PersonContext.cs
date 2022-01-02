using Microsoft.EntityFrameworkCore;
using PersonInfo.Models;

namespace PersonInfo.Data
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> PersonTbl { get; set; }

        public PersonContext(DbContextOptions<PersonContext> opt) : base(opt) { }
    }
}
