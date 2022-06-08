using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            AppConfiguration Settings = new ();
          
            DbContextOptionsBuilder<DatabaseContext> OptionsBuilder = new ();
           
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
            
            return new DatabaseContext(OptionsBuilder.Options);
        }
    }
}
