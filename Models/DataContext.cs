using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Chapter18.Models {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> opts)
            : base(opts) { }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Classification> Classifications => Set<Classification>();
        public DbSet<Publisher> Publishers => Set<Publisher>();
    }



 /*public class DataContext : DbContext
{
//Dbcontext implementation
}*/

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        
        optionsBuilder.UseSqlite( "Data Source = {BU.db}");

        return new DataContext(optionsBuilder.Options);
    }
}
}

