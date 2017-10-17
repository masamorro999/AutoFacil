namespace AutosRA.Domain
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("AutoRAConnection")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
