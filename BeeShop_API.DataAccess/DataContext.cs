using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BeeShop_API.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<UserSessions> UserSessions { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<UserSessions>().ToTable("UserSessions");
            modelBuilder.Entity<ProductCategories>().ToTable("ProductCategories");
            modelBuilder.Entity<Roles>().ToTable("Roles");
            modelBuilder.Entity<UserRoles>().ToTable("UserRoles");
            // Thiết lập khóa chính cho UserRole
            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Thiết lập quan hệ giữa User và UserRole
            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            // Thiết lập quan hệ giữa Role và UserRole
            modelBuilder.Entity<UserRoles>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
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
