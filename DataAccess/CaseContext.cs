using Entitities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess
{
    public class CaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-0L93GJT\\SQLEXPRESS; Initial Catalog = CaseDb; Integrated Security = True; Encrypt = False; Connection Timeout = 60");
        }
        public DbSet<TblData> TblData { get; set; }
        public DbSet<TblDataYedek> TblDataYedek { get; set; }


    }
}
