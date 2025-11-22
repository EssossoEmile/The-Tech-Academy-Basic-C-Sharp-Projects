using System.Data.Entity;

namespace CodeFirstStudent
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("SchoolDB") // Database will be named SchoolDB.mdf
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
