using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeeShop_API.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<UserSessions>().ToTable("UserSessions");
        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer(LoadConfiguration().GetConnectionString("ConnectionString"));
//            }
//        }

        //private static IConfigurationRoot LoadConfiguration()
        //{
        //    var jsonFile = "appsettings.json";
        //    try
        //    {
        //        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLower() == "development")
        //        {
        //            jsonFile = "appsettings.Development.json";
        //        }
        //    }
        //    catch { }

        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile(jsonFile, true, true);

        //    var configuration = builder.Build();
        //    return configuration;
        //}
    }
}
