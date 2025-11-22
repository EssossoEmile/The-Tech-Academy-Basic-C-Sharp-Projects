using System.Data.Entity;

namespace CarInsurance.Models
{
    public class InsuranceContext : DbContext
    {
        // This connection name should match your Web.config / EDMX connection if you use the designer
        public InsuranceContext() : base("InsuranceEntities") { }

        public DbSet<Insuree> Insurees { get; set; }
    }
}
